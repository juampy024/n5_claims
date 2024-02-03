using N5_API.Project.Base.Model;

namespace N5_API.Project.Models
{
    public class Person : PersistentBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDay { get; set; } 
        public bool IsActive { get; set; }

        // Navigation property for the Employee entity
        public virtual Employee Employee { get; set; }
    }
}
