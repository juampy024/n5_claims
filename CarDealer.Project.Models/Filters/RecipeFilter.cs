using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Models
{
    public class RecipeFilter
    {

        public int IdPharmacy { get; set; }
        public int[] Ids { get; set; }
        public int[] StatusIds { get; set; } = new int[0];
        public int[] ClinicalServicesIds { get; set; } = new int[0];
        public int[] NurseStationsIds { get; set; } = new int[0];
        public int[] PatientsIds { get; set; } = new int[0];
    }
}
