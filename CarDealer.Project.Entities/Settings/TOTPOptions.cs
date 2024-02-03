using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Entities.Settings
{
    public class TOTPOptions
    {
        public string TOTPIssuer { get; set; }
        public string TOTPAccountPrefix { get; set; }
        public int TOTPTimestep { get; set; }
        public string EncryptionKey { get; set; }
    }
}
