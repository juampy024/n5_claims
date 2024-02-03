using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Entities.AzureB2C
{
    public class AzureInfoResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int not_before { get; set; }
        public int expires_in { get; set; }
        public int expires_on { get; set; }
        public string resource { get; set; }
        public string profile_info { get; set; }
        public string scope { get; set; }
    }
}
