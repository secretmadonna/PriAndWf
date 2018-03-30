using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.Web.Models
{
    public class AccountViewModel
    {
        public SignUpViewModel SignUp { get; set; }
        public LoginViewModel Login { get; set; }
        public ForgotViewModel Forgot { get; set; }
    }
}