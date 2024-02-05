using N5_API.Project.Base.Models;
using N5_API.Project.Repositories.ElasticSearch;
using N5_API.Project.Services.Interfaces;
using N5_API.Project.UoW;
using System.Security;

namespace N5_API.Project.Services
{
    public class PermissionService : IPermissionService
    {   
        IUnitOfWorkSql _uow;
        private readonly IPermissionSearchRepository _permissionSearchRepository;

        public PermissionService(IUnitOfWorkSql uow, IPermissionSearchRepository permissionSearchRepository) {

            _uow = uow;
            _uow.InitializePermission();
            _permissionSearchRepository = permissionSearchRepository;

        }

        public void Dispose()
        {
            _uow.Dispose();
        }

        public async Task<Permission?> GetPermissionAsync(int id)
        {
            var permission = await _permissionSearchRepository.GetPermissionByIdAsync(id.ToString());

            if (permission == null)
            {
                permission = await _uow.Permission.GetPermissionAsync(id);

                if (permission != null)
                {
                    // Index the permission into Elasticsearch
                    await _permissionSearchRepository.IndexPermissionAsync(permission);
                }
            }

            return permission;
        }
        public async Task<Permission> ModifyPermissionAsync(Permission permission)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var permissionToUpdate = await _uow.Permission.GetPermissionAsync(permission.Id);

                // add concurrency check here
                if (permissionToUpdate == null) return null;

                permissionToUpdate.Description = permission.Description;
                permissionToUpdate.PermissionTypeId = permission.PermissionTypeId;
                permissionToUpdate.LastUpdated = DateTime.Now;


                var permissionUpdated = await _uow.Permission.ModifyPermissionAsync(permissionToUpdate);

                if (permissionUpdated == null) return null;

                // Index the permission into Elasticsearch
                bool isUpdated = await _permissionSearchRepository.UpdatePermissionByIdAsync(permissionUpdated.Id.ToString(), permissionUpdated);

                await _uow.BeginTransactionAsync();

                return permissionUpdated;

            }catch(Exception ex)
            {
                
                await _uow.RollbackAsync();
                string exceptionDetails = ExceptionHelper.IdentifyException(ex);
                throw new Exception(exceptionDetails);
            }
        }
    }
}
