using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Models.Blob
{
    public class ClaimsBlobDTO
    {     
        public ClaimsBlobDetailDTO[] Claims { get; set; }
    }

    public class ClaimsBlobDetailDTO
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
