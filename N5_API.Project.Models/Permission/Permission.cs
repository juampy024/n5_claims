using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public int PermissionTypeId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime LastUpdated { get; set; }

        // Navigation properties
        public virtual PermissionType PermissionType { get; set; } = new PermissionType();
        public virtual ICollection<PermissionEmployee> PermissionEmployees { get; set; } = new List<PermissionEmployee>();
    }
}
