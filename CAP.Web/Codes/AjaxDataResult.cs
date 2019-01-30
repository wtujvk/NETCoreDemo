using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.Web.Codes
{
    /// <summary>
    /// ajax数据封装。
    /// </summary>
    public class AjaxDataResult
    {
        /// <summary>
        /// 是否成功 。
        /// </summary>
        public bool Ok { get; set; }

        /// <summary>
        /// 消息。
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 获取对象。
        /// </summary>
        /// <returns>AjaxDataResult。</returns>
        public static AjaxDataResult GetDataResult()
        {
            return new AjaxDataResult() { Ok = false, Msg = "未处理的异常" };
        }
    }

    /// <summary>
    /// ajax数据封装。
    /// </summary>
    public class AjaxDataResult<T> : AjaxDataResult
    {
        /// <summary>
        /// 数据。
        /// </summary>
        public T Res { get; set; }

        /// <summary>
        /// 获取对象。
        /// </summary>
        /// <returns>AjaxDataResult。</returns>
        public new static AjaxDataResult<T> GetDataResult()
        {
            return new AjaxDataResult<T>() { Ok = false, Msg = "未处理的异常", Res = default(T) };
        }
    }
}
