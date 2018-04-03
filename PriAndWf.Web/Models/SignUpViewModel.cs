using PriAndWf.Web.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriAndWf.Web.Models
{
    public class SignUpViewModel
    {
        [Display(Description = "", Name = "", ResourceType = typeof(Resources), ShortName = "")]
        [DisplayName]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SignUp_Email", ErrorMessageResourceType = typeof(Resources))]
        [Remote("AjaxValidateEmail", "Account")]
        public string Email { get; set; }
        [Remote("AjaxValidateUsername", "Account")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}