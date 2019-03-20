using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace learning.common.tests.utils.FaKe
{
    class FakeDictionary : IDictionary
    {
        Dictionary<object, object> data = new Dictionary<object, object>();
        public void Add(object key, object value)
        {
            data.Add(key, value);
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public ICollection Keys
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public ICollection Values
        {
            get { throw new NotImplementedException(); }
        }

        public object this[object key]
        {
            get
            { 
                return data[key];
            }
            set
            {
                data[key] = value;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
