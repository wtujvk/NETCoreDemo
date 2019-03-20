using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace learning.common.tests.utils
{
    public class HttpContextModelTool
    {
        public HttpContextModelTool() { }
        public HttpContextModelTool(HrParam param, HttpWebRequest request) 
        {
            Param = param;
            Request = request;
        }
        public  HttpWebResponse Response { get; set; }
        public string ResponseBody { get; set; }
        public  HttpWebRequest Request { get; set; }
        public  HrParam Param { get; set; }


    }
}
