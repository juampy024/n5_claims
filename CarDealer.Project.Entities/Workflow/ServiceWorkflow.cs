using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Entities.Workflow
{
    public class ServiceWorkflow
    {
        public bool Correct { get; set; }
        public dynamic Data { get; set; }

        public ServiceWorkflow()
        {
            this.Correct = false;
            this.Data = string.Empty;
        }

        public ServiceWorkflow(bool _correct, dynamic _data)
        {
            this.Correct = _correct;
            this.Data = _data;
        }
    }
}
