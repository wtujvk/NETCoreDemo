using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace learning.common.tests.utils.Exceptions
{
    public class CustomerException : System.Exception
    {
        private readonly NameValueCollection nameValues = new NameValueCollection();
        public CustomerException(string message, params KVPair[] kvs)
            : base(message)
        {
            StackTrace = Environment.StackTrace;
            foreach (var item in kvs)
            {
                nameValues.Add(item.Key, item.Value);
            }
        }

        public override string ToString()
        {
            return Message;
        }

        public string this[string key]
        {
            get => nameValues.Get(key);
            set => nameValues.Add(key, value);
        }

        /// <summary>
        /// 获取调用堆栈上直接帧的字符串表示形式。
        /// 用于描述调用堆栈的直接帧的字符串。
        /// </summary>
        public override string StackTrace { get; } = string.Empty;

        public string[] Keys => nameValues.AllKeys;
    }
}
