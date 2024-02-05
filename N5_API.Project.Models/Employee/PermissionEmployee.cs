using N5_API.Project.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Models
{
    public class PermissionEmployee
    {
        // Composite key configuration needed in OnModelCreating
        public int PermissionId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime AssignmentDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual Permission Permission { get; set; } = new Permission();
        public virtual Employee Employee { get; set; } = new Employee();
    }
}
