using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Text;

namespace N5_API.Project.Entities.AzureB2C
{
    public class B2CResponseDTO
    {
        public string version { get; set; }
        public int status { get; set; }
        public string userMessage { get; set; }

        // Optional claims
        public string qrCodeBitmap { get; set; }
        public string secretKey { get; set; }
        public string timeStepMatched { get; set; }

        public B2CResponseDTO(string message, HttpStatusCode status)
        {
            this.userMessage = message;
            this.status = (int)status;
            this.version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
