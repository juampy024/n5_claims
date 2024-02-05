using Microsoft.EntityFrameworkCore;
using N5_API.Project.Base.Models;


namespace N5_API.Project.Repositories.SQLServer
{
    public class PermissionRepository : IPermissionRepository
    {
        protected readonly N5Context _context;

        public PermissionRepository(N5Context context)
        {
            _context = context;
        }

        public async Task<Permission> GetPermissionAsync(int id)
        {
            try 
            { 
                var permission = await _context.Permission.FindAsync(id);

                if(permission == null)
                {
                    throw new ArgumentNullException(nameof(permission));
                }
                return permission;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
        {
            try
            {
                var permissions = await _context.Permission.ToListAsync<Permission>();
                return permissions;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Permission> ModifyPermissionAsync(Permission permission)
        {
            try
            {
                if (permission == null)
                {
                    throw new ArgumentNullException(nameof(permission));
                }
                _context.Permission.Update(permission);
                _context.SaveChangesAsync();

                return Task.FromResult(permission);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
