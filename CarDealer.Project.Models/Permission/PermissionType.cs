using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Models
{
    public class PermissionType
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdated { get; set; }

        // Navigation property for the Permission entity
        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
