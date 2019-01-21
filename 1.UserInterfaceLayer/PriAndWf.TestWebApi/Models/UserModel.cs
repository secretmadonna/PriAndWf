using System;
using System.ComponentModel.DataAnnotations;

namespace PriAndWf.TestWebApi.Models
{
    public class UserModel
    {
        [Display(Name = "用户编号", Description = @"用户编号")]
        [Required(ErrorMessage = "{0} 不能为空")]
        [RegularExpression(@"^([+-]?)\d*$", ErrorMessage = "{0} 输入格式错误。")]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string NickName { get; set; }
        public UserGender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool Active { get; set; }
    }
    public enum UserGender
    {
        Unknown = 0,
        Male,
        Female
    }
}
