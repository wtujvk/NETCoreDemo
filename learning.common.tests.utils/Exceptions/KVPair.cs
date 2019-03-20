using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learning.common.tests.utils.Exceptions
{
    public class KVPair
    {
        public KVPair(string key, string value) 
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
