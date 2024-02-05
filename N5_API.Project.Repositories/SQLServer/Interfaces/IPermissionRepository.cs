using N5_API.Project.Base.Models;

namespace N5_API.Project.Repositories.SQLServer
{
    public interface IPermissionRepository
    {
        Task<Permission> GetPermissionAsync(int id);
        Task<Permission> ModifyPermissionAsync(Permission permission);
        Task<IEnumerable<Permission>> GetAllPermissionsAsync();

    }
}
