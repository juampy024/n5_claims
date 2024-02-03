using N5_API.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
