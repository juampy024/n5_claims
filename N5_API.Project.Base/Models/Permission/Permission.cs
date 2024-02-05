using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace N5_API.Project.Base.Models
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

    }
}
