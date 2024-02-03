using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Entities.Options
{
    public class RabbitQueue
    {
        /// <summary>
        /// Name of the queue 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of object that queue will process. Also used to identify the queue name.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Base url of the endpoint than will use to retry
        /// </summary>
        public string Endpoint { get; set; }
        /// <summary>
        /// Time of base delay used to make a retry. It will be incremented exponencially on each retry.
        /// </summary>
        public int Delay { get; set; }
    }
}
