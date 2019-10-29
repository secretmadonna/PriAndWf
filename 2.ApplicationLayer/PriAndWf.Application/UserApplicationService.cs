using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriAndWf.Application
{
    public class UserApplicationService
    {
        /// <summary>
        /// 根据登录名获取用户
        ///   密码：明文、加密（对称加密、非对称加密、不可逆加密（散列？？？））
        /// </summary>
        /// <param name="loginName">用户名、手机号、邮箱</param>
        /// <returns></returns>
        public UserDto GetByLoginName(string loginName)
        {
            return new UserDto()
            {
                UserId = "12345678",
                UserName = "test",
                Password = "123456",
            };
        }
    }
}
