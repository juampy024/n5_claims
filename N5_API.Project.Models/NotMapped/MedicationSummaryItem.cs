using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace N5_API.Project.Models.NotMapped
{
    public class MedicationSummaryItem
    {
        [Description("status")]
        public eMedicationRequestStatus Status { get; set; }
        [Description("quantity")]
        public int Quantity { get; set; }
    }
}
