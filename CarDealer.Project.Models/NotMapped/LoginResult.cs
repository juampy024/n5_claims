using System;
using System.Collections.Generic;
using System.Text;

namespace N5_API.Project.Models.NotMapped
{
    public class LoginResult
    {
        public int id { get; set; }
        public string username {  get; set; }
        public string email { get; set; }
        public string jwToken { get; set; }
    }
}