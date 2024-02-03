using System.Collections.Generic;

namespace N5_API.Project.Entities.Options
{
    public class RabbitSettings
    {
        public string Url { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public List<RabbitQueue> Queues { get; set; }
    }
}
