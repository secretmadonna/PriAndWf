using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.Web.Models
{
    public class AccountViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public SignUpViewModel SignUpViewModel { get; set; }
        public ForgotViewModel ForgotViewModel { get; set; }
    }
}