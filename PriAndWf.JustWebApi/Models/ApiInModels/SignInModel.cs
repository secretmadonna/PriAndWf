using System.ComponentModel.DataAnnotations;

namespace PriAndWf.JustWebApi.Models.ApiInModels
{
    public class SignInModel
    {
        /// <summary>
        /// 考试场次编号
        ///   传入
        /// </summary>
        [Display(Name = "考试场次编号", Description = @"考试场次编号")]
        [Required(ErrorMessage = "{0} 不能为空")]
        //[RegularExpression(@"^([+-]?)\d*$", ErrorMessage = "{0}输入格式错误。")]
        public int ExamBatchSessionId { get; set; }
        /// <summary>
        /// 身份证号
        ///   传入
        /// </summary>
        [Display(Name = "身份证号", Description = @"身份证号")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} 不能为空或空串或空白字符串")]
        [StringLength(18, MinimumLength = 0, ErrorMessage = "{0} 字符数必须大于等于 {2} 和小于等于 {1}")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 设备
        ///   传入
        /// </summary>
        [Display(Name = "设备编号", Description = @"设备编号")]
        //[Required(ErrorMessage = "{0} 不能为空")]
        [StringLength(20, MinimumLength = 0, ErrorMessage = "{0} 字符数必须大于等于 {2} 和小于等于 {1}")]
        public string EquipmentId { get; set; }
        /// <summary>
        /// 签到方式
        ///   C、电脑签到；I、苹果手机签到；A、安卓手机签到；O、其他签到
        ///   传入（WEB端不传，手机APP端传入）
        /// </summary>
        [Display(Name = "签到方式", Description = @"签到方式")]
        [StringLength(1, MinimumLength = 0, ErrorMessage = "{0} 字符数必须大于等于 {2} 和小于等于 {1}")]
        public string SigninType { get; set; }
        /// <summary>
        /// 签到时的GPS
        ///   传入（仅针对手机）
        /// </summary>
        [Display(Name = "GPS", Description = @"GPS")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "{0} 字符数必须大于等于 {2} 和小于等于 {1}")]
        public string SigninGps { get; set; }


        /// <summary>
        /// 考点
        ///   从登录信息中获取
        /// </summary>
        [Display(Name = "考点", Description = @"考点")]
        public int StudyCenterSpotId { get; set; }

        /// <summary>
        /// 签到时的IP
        ///   从请求中获取
        /// </summary>
        [Display(Name = "IP", Description = @"IP")]
        [StringLength(19, MinimumLength = 0, ErrorMessage = "{0} 字符数必须大于等于 {2} 和小于等于 {1}")]
        public string SigninIp { get; set; }
    }
}