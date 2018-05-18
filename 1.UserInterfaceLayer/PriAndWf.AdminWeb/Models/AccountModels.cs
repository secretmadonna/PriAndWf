using PriAndWf.AdminWeb.Properties;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PriAndWf.AdminWeb.Models
{
    public class LoginViewModel
    {
        [Display(Name = "登录名", Description = "用户名/邮箱/手机")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required_Default", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength_Default", ErrorMessageResourceType = typeof(Resources))]
        public string LoginName { get; set; }
        [Display(Name = "密码", Description = "密码")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required_Default", ErrorMessageResourceType = typeof(Resources))]
        [MaxLength(50, ErrorMessageResourceName = "MaxLength_Default", ErrorMessageResourceType = typeof(Resources))]
        [DataType(DataType.Password, ErrorMessageResourceName = "DataType_Default", ErrorMessageResourceType = typeof(Resources))]
        public string PassWord { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        public string Email { get; set; }
    }

    public class SignupViewModel
    {
        [Display(Description = "", Name = "", ResourceType = typeof(Resources), ShortName = "")]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SignUp_Email", ErrorMessageResourceType = typeof(Resources))]
        [Remote("AjaxValidateEmail", "Account")]
        public string Email { get; set; }
        [Remote("AjaxValidateUsername", "Account")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}