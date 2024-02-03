using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Models.NotMapped
{
    public class StorageToUpdate
    {
        public int IdPharmacy { get; set; }
        public Guid PharmacyTid { get; set; }

        public int[] New { get; set; }
        public int[] Enabled { get; set; }
        public int[] Disabled { get; set; }
    }
}
