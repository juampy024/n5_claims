using N5_API.Project.Base.Models;
using N5_API.Project.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Repositories.ElasticSearch
{
    public interface IPermissionSearchRepository
    {
        Task<IndexResponse> IndexPermissionAsync(Permission permission);
        Task<Permission?> GetPermissionByIdAsync(string id);

        public Task<bool> UpdatePermissionByIdAsync(string id, Permission permission);

    }
}

