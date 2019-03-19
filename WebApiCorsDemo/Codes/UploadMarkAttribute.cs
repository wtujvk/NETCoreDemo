using System;

namespace WebApiCorsDemo.Codes
{
    /// <summary>
    /// 上传文件标记。
    /// </summary>
    internal class UploadMarkAttribute : Attribute
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DescriptionName { get; set; }

        /// <summary>
        /// 是否是必须的
        /// </summary>
        public bool Require { get; set; }
        public UploadMarkAttribute(string name = "", bool require = false)
        {
            DescriptionName = name;
            Require = require;
        }
    }
}