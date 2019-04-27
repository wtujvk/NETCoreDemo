using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace learning.LogMvcDemo.Codes.Entitys
{
    /// <summary>
    /// 日志实体。
    /// </summary>
    public class LoginEntity: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        /// <summary>
        /// appid。
        /// </summary>
        [Display(Name = "应用id")]
        public int AppId { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 源。
        /// </summary>
        [MaxLength(100)]
        [Display(Name = "源")]
        public string Origin { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "日志级别")]
        public string LogLevel { get; set; }

        /// <summary>
        /// 消息。
        /// </summary>
        [Display(Name = "消息")]
        public string Message { get; set; }

        /// <summary>
        /// 堆栈消息。
        /// </summary>
        [Display(Name = "堆栈消息")]
        public string StackTrace { get; set; }
    }
}