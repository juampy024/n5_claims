using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Base.Model
{
    public class PersistentBase
    {
        [Description("Id")]
        public int Id { get; set; }

        [Description("Deleted")]
        public bool Deleted { get; set; }

        [Description("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Description("DeletedDate")]
        public DateTime? DeletedDate{ get; set; }

        [Description("LastUpdated")]

        public DateTime? LastUpdated { get; set; }

    }
}
