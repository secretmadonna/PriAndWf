using System.ComponentModel.DataAnnotations;

namespace PriAndWf.TestWebApi.Models.ApiInModels
{
    public class SignInModel
    {
        /// <summary>
        /// 考试场次编号
        ///   传入
        /// </summary>
        [Display(Name = "考试场次编号", Description = @"考试场次编号")]
        //[Required(ErrorMessage = "{0} 不能为空")]
        //[RegularExpression(@"^([+-]?)\d*$", ErrorMessage = "{0}输入格式错误。")]
        public int ExamBatchSessionId { get; set; }
    }
}