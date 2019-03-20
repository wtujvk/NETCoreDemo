using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace learning.common.tests.utils
{
    /// <summary>
    /// http Request Param
    /// </summary>
    public class HrParam
    {
        public HrParam()
        {
            Files = new Param();
            Params = new Param();
            Headers = new Param();
        }
        public Param Params;
        public Param Files;
        public Param Headers;
    }
    public class Param
    {
        NameValueCollection nameValues = new NameValueCollection();
        public string this[string name]
        {
            get { return nameValues.Get(name); }
            set => nameValues.Add(name,value);
        }

        public string[] Keys => nameValues.AllKeys;
    }
}
