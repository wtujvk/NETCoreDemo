using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.Web.Codes
{
    /// <summary>
    /// 消息体。
    /// </summary>
    public class MessageBody
    {
        /// <summary>
        /// 名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 消息创建时间。
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 消息内容。
        /// </summary>
        public string MessageContext { get; set; }

        /// <summary>
        /// 标记，签名。
        /// </summary>
        public string Sign { get; set; }
    }
}
