using N5_API.Project.Models.NotMapped;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.PostgreSql.Interfaces
{
    public interface IExternalAPIRepository
    {
        Task<Response> Get(string endpoint, bool useAuthorization = false, string authType = null, string authScheme = null);
        Task<Response> Post(string endpoint, string payload, bool useAuthorization = false, string authType = null, string authScheme = null);
        Task<Response> Put(string endpoint, string payload, bool useAuthorization = false, string authType = null, string authScheme = null);
        Task<Response> GetJasper(string endpoint, bool useAuthorization = false, string authType = null, string authScheme = null);
    }
}