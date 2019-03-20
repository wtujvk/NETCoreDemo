using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace learning.common.tests.utils.FaKe
{
    public class FakeHttpResponse : HttpResponseBase
    {
        HttpCookieCollection _cookies;
        Dictionary<string, string> header = new Dictionary<string, string>();
        public FakeHttpResponse()
        {
            _cookies = new HttpCookieCollection();
        }
        public override HttpCookieCollection Cookies
        {
            get
            {
                return _cookies;
            }
        }

        public override void AddHeader(string name, string value)
        {
            header.Add(name, value);
        }
        public override void Write(object obj)
        {
            //base.Write(obj);
        }
        public override void Write(string s)
        {
            //base.Write(s);
        }
    }
}
