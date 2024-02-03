using N5_API.Project.Models;
using Nest;

public class ElasticSearchSetup
{
    private readonly IElasticClient _elasticClient;

    public ElasticSearchSetup(IElasticClient elasticClient)
    {
        _elasticClient = elasticClient;
    }

    public async Task CreateIndexIfNotExistsAsync(string indexName)
    {
        var existsResponse = await _elasticClient.Indices.ExistsAsync(indexName);

        if (!existsResponse.Exists)
        {
            var createIndexResponse = await _elasticClient.Indices.CreateAsync(indexName, c => c
                .Map<Permission>(m => m.AutoMap())
            );

            if (!createIndexResponse.IsValid)
            {
                // Log the error or throw an exception
                throw new Exception($"Failed to create index: {createIndexResponse.DebugInformation}");
            }
        }
    }
}
