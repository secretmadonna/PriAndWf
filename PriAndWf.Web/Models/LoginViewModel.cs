using PriAndWf.Web.Properties;
using System.ComponentModel.DataAnnotations;

namespace PriAndWf.Web.Models
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
}