using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace learning.LogMvcDemo.Models
{
    /// <summary>
    /// 日志数据模型。
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// 应用id。
        /// </summary>
        public int AppId { get; set; }

        /// <summary>
        /// 安全密钥
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        [Required]
        public string Level { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 堆栈消息。
        /// </summary>
        public string StackTrace { get; set; }
    }
}