using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.Web.Models
{
    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}