using Elasticsearch.Net;
using N5_API.Project.Base.Models;
using N5_API.Project.Models;
using Nest;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace N5_API.Project.Repositories.ElasticSearch
{
    public class PermissionsSearchRepository : IPermissionSearchRepository
    {
        private readonly IElasticClient _elasticClient;

        public PermissionsSearchRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<IndexResponse> IndexPermissionAsync(Permission permission)
        {
            var response = await _elasticClient.IndexDocumentAsync(permission);

            if (!response.IsValid)
            {
                // Log the error or handle it as needed
                // The response will contain information about what went wrong
                throw new Exception($"Failed to index document: {response.OriginalException.Message}");
            }

            return response;
        }

        public async Task<Permission?> GetPermissionByIdAsync(string documentId)
        {
            var getResponse = await _elasticClient.GetAsync<Permission>(documentId, idx => idx.Index("permission"));

            if (getResponse.Found)
            {
                return getResponse.Source;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdatePermissionByIdAsync(string documentId, Permission updatedPermission)
        {
            var updateResponse = await _elasticClient.UpdateAsync<Permission>(DocumentPath<Permission>.Id(documentId), u => u
                .Index("permission")
                .Doc(updatedPermission)
                .Refresh(Refresh.WaitFor)
            );

            if (updateResponse.IsValid)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

    }
}
