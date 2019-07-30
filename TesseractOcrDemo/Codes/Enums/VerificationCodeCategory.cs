using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesseractOcrDemo.Codes.Enums
{
    /// <summary>
    /// 验证码类别（可组合使用）。
    /// </summary>
    [Flags]
    public enum VerificationCodeCategory
    {
        /// <summary>
        /// 纯数字。
        /// </summary>
        Number = 1,

        /// <summary>
        /// 小写。
        /// </summary>
        Lowercase = 2,

        /// <summary>
        /// 大写。
        /// </summary>
        Uppercase = 4,

        /// <summary>
        /// 特殊符号。
        /// </summary>
        Symbols = 8
    }
}