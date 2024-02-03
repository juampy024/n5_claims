using N5_API.Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.ElasticSearch
{
    public interface IPermissionSearchRepository
    {            
        Task IndexPermissionAsync(Permission permission);
        Task<IEnumerable<Permission>> SearchPermissionsAsync(int query);
        Task<Permission?> SearchPermissionAsync(int id);





    }
}

