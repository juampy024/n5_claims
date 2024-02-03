using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace N5_API.Project.Models.NotMapped
{
    public class Response
    {
        public Response()
        {
            IsSuccess = false;
        }
        public string Content { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode ResultCode { get; set; }
    }
}
