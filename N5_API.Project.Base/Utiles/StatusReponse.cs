using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5_API.Project.Base.Utiles
{
    public class StatusReponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public StatusReponse(int statusCode, string message, T? data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
