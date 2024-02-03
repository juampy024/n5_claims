using N5_API.Project.Models;
namespace N5_API.Project.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Permission?> GetPermissionAsync(int id);
        Task<Permission> ModifyPermissionAsync(Permission permission);

        void Dispose();

    }
}
