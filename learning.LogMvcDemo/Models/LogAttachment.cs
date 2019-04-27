using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace learning.LogMvcDemo.Models
{
    /// <summary>
    /// 日志附件。
    /// </summary>
    public class LogAttachment
    {
        /// <summary>
        /// 普通文本消息，支持\n换行
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标题链接。
        /// </summary>
        public string TitleLink { get; set; }

        /// <summary>
        /// 在显示消息正文之前显示的文本内容。
        /// </summary>
        public string Pretext { get; set; }

        /// <summary>
        /// 将消息的正文用指定的颜色进行标示。
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 用于移动端将提示信息显示在首页上。
        /// </summary>
        public string Fallback { get; set; }

        /// <summary>
        /// 用于显示作者名。
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 作者主页超链接。
        /// </summary>
        public string AuthorLink { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string AuthorIcon { get; set; }

        /// <summary>
        /// 日志字段集合。
        /// </summary>
        public List<LogField> Fields { get; set; }
    }
}