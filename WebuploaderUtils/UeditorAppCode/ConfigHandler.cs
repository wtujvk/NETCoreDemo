using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebuploaderUtils.UeditorAppCode
{
    /// <summary>
    /// Config 的摘要说明
    /// </summary>
    public class ConfigHandler : UeHandler
    {
        public ConfigHandler(HttpContext context) : base(context)
        {
        }

        public override void Process()
        {
            WriteJson(UeditorConfig.Items);
        }
    }
}