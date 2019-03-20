using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using learning.common.tests.utils.Exceptions;

namespace learning.common.tests.utils
{
    public class HttpTestsTool
    {
        public static HttpTestsTool GetInstance
        {
            get { return instance; }
        }
        private static readonly HttpTestsTool instance = new HttpTestsTool();
        private HttpTestsTool()
        {
            Host = ConfigurationManager.AppSettings["TestHostName"];
            encoding = Encoding.GetEncoding(ConfigurationManager.AppSettings["TestEncoding"]);
            cookie = new CookieContainer();
        }
        public bool IsStart = false;
        public string Host = string.Empty;
        public Encoding encoding;
        private CookieContainer cookie = null;

        /// <summary>
        /// 开始测试请求
        /// </summary>
        /// <param name="path">请求路径，不包含协议主机名端口，如：http://localhost:80/test 的话传入“/test”即可</param>
        /// <param name="httpMethod">请求方式。</param>
        /// <param name="param">请求参数</param>
        /// <returns></returns>
        public HttpContextModelTool Test(string path, HttpMethodEn httpMethod = HttpMethodEn.GET, HrParam param = null)
        {
            if (param == null) param = new HrParam();

            string url = $"http://{Host}{path}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AllowAutoRedirect = false;//获取或设置一个值，该值指示请求是否应跟随重定向响应。
            //request.MaximumAutomaticRedirections = 2;//获取或设置请求将跟随的重定向的最大数目。默认值为50
            if (cookie != null) request.CookieContainer = cookie;


            HttpContextModelTool httpContextTestTool = new HttpContextModelTool(param, request);
            if (httpMethod == HttpMethodEn.GET)
            {
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
            }
            else if (httpMethod == HttpMethodEn.AJAXPOST)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in param.Params.Keys)
                {
                    sb.AppendFormat("{0}={1}&", item, param.Params[item]);
                }
                string postDataStr = sb.ToString();
                if (postDataStr.Length > 0)
                {
                    postDataStr = postDataStr.Substring(0, postDataStr.Length - 1);
                }


                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=" + encoding.ToString();

                request.ContentLength = encoding.GetByteCount(postDataStr);
                Stream myRequestStream = request.GetRequestStream();
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
                myStreamWriter.Write(postDataStr);
                myStreamWriter.Close();
            }
            else
            {
                throw new Exception("传入错误的httpMethod");
            }

            httpContextTestTool.Response = (HttpWebResponse)httpContextTestTool.Request.GetResponse();
            int StatusCode = (int)httpContextTestTool.Response.StatusCode;
            if (StatusCode != 200)
            {
                if (StatusCode == 302)
                {
                    throw new CustomerException("状态码为" + StatusCode, new KVPair("ECode", "101"), new KVPair("val", StatusCode.ToString()));
                }
            }

            cookie.Add(httpContextTestTool.Response.Cookies);

            using (StreamReader stream = new StreamReader(httpContextTestTool.Response.GetResponseStream()))
            {
                httpContextTestTool.ResponseBody = stream.ReadToEnd();
                stream.Close();
            }

            httpContextTestTool.Response.Close();
            return httpContextTestTool;
        }


    }
}
