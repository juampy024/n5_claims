using N5_API.Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Models
{
    public class Employee : PersistentBase
    {
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public bool IsActive { get; set; }


        // Navigation properties
        public virtual Person Person { get; set; }
        public virtual ICollection<PermissionEmployee> PermissionEmployees { get; set; }
    }
}
