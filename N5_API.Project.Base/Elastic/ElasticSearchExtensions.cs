using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N5_API.Project.Base.Models;
using Nest;


namespace N5_API.Project.Base.Elastic
{
    public static class ElasticSearchExtensions
    {
        public static string GetIndexName<T>() where T : class
        {
            return typeof(T).Name.ToLower();
        }

        public static void AddElasticSearch(
            this IServiceCollection services, IConfiguration configuration
            )
        {
            var url = configuration["ElasticSearchSetting:Uri"];
            var defaultIndex = configuration["ElasticSearchSetting:Index"];

            var settings = new ConnectionSettings(new Uri(url))
                .PrettyJson().DefaultIndex(defaultIndex).EnableApiVersioningHeader();
            
            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndexIfNotExists(client, defaultIndex);
        }

        private static void AddDefaultMappings(this ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Permission>(m => m
                           .IndexName(GetIndexName<Permission>())
                                          .IdProperty(p => p.Id)
                                                     );
        }

        private static void CreateIndexIfNotExists(this IElasticClient client, string indexName)
        {            
            if (!client.Indices.Exists(indexName).Exists)
            {
                var resposnse = client.Indices.Create(indexName, c => c.Map<Permission>(m => m.AutoMap()));

                if (!resposnse.IsValid)
                {
                    throw new System.Exception($"Failed to create index {indexName}");
                }
            }
        }
    }
}
