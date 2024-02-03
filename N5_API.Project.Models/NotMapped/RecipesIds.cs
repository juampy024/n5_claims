using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace N5_API.Project.Models.NotMapped
{
    public class RecipesIds
    {
        [Description("id")]
        public long Id { get; set; }
        [Description("last_date")]
        public DateTime LastDate { get; set; }
    }
}
