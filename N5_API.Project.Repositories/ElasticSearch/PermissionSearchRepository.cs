using N5_API.Project.Models;
using Nest;

namespace N5_API.Project.Repositories.ElasticSearch
{
    public class PermissionsSearchRepository : IPermissionSearchRepository
    {
        private readonly IElasticClient _elasticClient;

        public PermissionsSearchRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public Task IndexPermissionAsync(Permission permission)
        {
            try
            {
                return _elasticClient.IndexDocumentAsync(permission);

            }
            catch (Exception ex)
            {
                throw new Exception("Error creating index", ex);
            }
        }

        public async Task<IEnumerable<Permission>> SearchPermissionsAsync(int query)
        {
            var searchResponse = await _elasticClient.SearchAsync<Permission>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Id)
                    )
                )
            );

            return searchResponse.Documents;
        }

        public async Task<Permission?> SearchPermissionAsync(int id)
        {
            var searchResponse = await _elasticClient.SearchAsync<Permission>(s => s
                .Query(q => q
                    .Term(t => t
                        .Field(f => f.Id)
                        .Value(id)
                    )
                )
                .Size(1)
            );

            if (searchResponse.IsValid && searchResponse.Documents.Any())
            {
                return searchResponse.Documents.First();
            }
            else
            {
                return null;
            }
        }

    }
}
