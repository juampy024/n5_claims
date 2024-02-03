using N5_API.Project.Models;
using N5_API.Project.Services.Interfaces;
using N5_API.Project.UoW;
using System.Security;

namespace N5_API.Project.Services
{
    public class PermissionService : IPermissionService
    {   
        IUnitOfWorkSql _uow;
        public PermissionService(IUnitOfWorkSql uow) {

            _uow = uow;
            _uow.InitializeEmployee();
        }
 

        public void Dispose()
        {
            _uow.Dispose();
        }
        /*public async Task<Permission?> Modify(Permission permission)
        {
            try
            {
                await _uow.BeginTransactionAsync();
                var result = await _uow.Permission.ModifyPermissionAsync(permission);
                await _uow.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                string exceptionDetails = ExceptionHelper.IdentifyException(ex);
                throw new Exception(exceptionDetails);
            }
        }*/
        public async Task<Permission?> GetPermissionAsync(int id)
        {
            var permission = await _uow.Permission.GetPermissionAsync(id);

            return permission;
        }
        public async Task<Permission?> ModifyPermissionAsync(Permission permission)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var employeeToUpdate = await _uow.Permission.ModifyPermissionAsync(permission);

                // add concurrency check here
                if (employeeToUpdate == null) return null;

                permission.LastUpdated = DateTime.Now;
                var employeeUpdated = await _uow.Permission.ModifyPermissionAsync(permission);

                await _uow.BeginTransactionAsync();

                return employeeUpdated;

            }catch(Exception ex)
            {
                string exceptionDetails = ExceptionHelper.IdentifyException(ex);
                throw new Exception(exceptionDetails);
            }
        }
    }
}
