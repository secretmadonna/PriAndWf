using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.TestWebApi.Models
{
    public class AccountModel
    {
    }
    public class Token
    {
        public string TokenType { get; set; }
        public string Scope { get; set; }

        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}