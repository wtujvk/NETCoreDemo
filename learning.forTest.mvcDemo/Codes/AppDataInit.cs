using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learning.forTest.mvcDemo.Codes
{
    /// <summary>
    /// 程序数据。
    /// </summary>
    public class AppDataInit
    {
        public const string LoginSessionKey = "login.web.key";

        public static IEnumerable<LoginUser> UserList = new List<LoginUser>();
    }
}