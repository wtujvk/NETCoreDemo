using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learning.LogMvcDemo.Models
{
    /// <summary>
    /// 字段。
    /// </summary>
    public class LogField
    { 
        /// <summary>
        /// 分区消息标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 分区消息内容
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 1:标识消息的内容时候时候为短消息
        /// </summary>
        [JsonProperty(PropertyName = "short")]
        public string ShortInfo { get; set; }
    }
}