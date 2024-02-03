using N5_API.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.SQLServer
{
    public interface IPermissionTypeRepository
    {
        Task<PermissionType> GetPermissionTypeAsync(string id);
        Task<PermissionType> ModifyPermissionTypeAsync(PermissionType permissionType);
    }
}
