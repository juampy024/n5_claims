using N5_API.Project.Models;
using N5_API.Project.Repositories.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.SQLServer
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        protected readonly N5Context _context;

        public PermissionTypeRepository(N5Context context)
        {
            _context = context;
        }
        public async Task<PermissionType> GetPermissionTypeAsync(string id)
        {
            try
            {

                var permissionType = await _context.PermissionType.FindAsync(id);
                
                if(permissionType == null)
                {
                    throw new ArgumentNullException(nameof(permissionType));
                }
                return permissionType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Task<PermissionType> ModifyPermissionTypeAsync(PermissionType permissionType)
        {
            try
            {
                if (permissionType == null)
                {
                    throw new ArgumentNullException(nameof(permissionType));
                }
                _context.PermissionType.Update(permissionType);
                _context.SaveChangesAsync();
                return Task.FromResult(permissionType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
