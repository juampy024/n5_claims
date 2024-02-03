using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Entities.RabbitMQ
{
    public class QueuePayload
    {
        public string QueueName { get; set; }
        public string URI { get; set; }
        public string Method { get; set; }
        public Type Type { get; set; }
        public string Content { get; set; }
        public int TryCounter { get; set; }
        public bool UseAuthentication { get; set; }
        public string AuthScheme { get; set; }
        public string AuthType { get; set; }
        public string Token { get; set; }
    }
}
