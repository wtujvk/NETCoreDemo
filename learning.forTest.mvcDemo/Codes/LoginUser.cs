using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learning.forTest.mvcDemo.Codes
{
    /// <summary>
    /// 登录用户。
    /// </summary>
    public class LoginUser
    {
        /// <summary>
        /// id。
        /// </summary>
        public Guid Uid { get; set; }

        /// <summary>
        /// 登录用户名。
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 显示用户名。
        /// </summary>
        public string ShowName { get; set; }

        /// <summary>
        /// 密码。
        /// </summary>
        public string PassWord { get; set; }
    }
}