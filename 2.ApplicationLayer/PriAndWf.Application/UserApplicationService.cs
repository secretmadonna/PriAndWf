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
        /// 
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
