using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CacheProxy<TIn, TOut>
    {
        private Dictionary<TIn, TOut> _proxy = new Dictionary<TIn, TOut>();
        internal Delegate _f;

        public CacheProxy()
        {
        }

        public TOut Invoke(TIn input)
        {
            if (_proxy.ContainsKey(input))
            {
                return _proxy[input];
            }

            var output = (TOut)_f.DynamicInvoke(input);

            _proxy[input] = output;

            return output;
        }
    }

    public class CacheProxy
    {
        public static CacheProxy<TIn, TOut> For<TIn, TOut>(Func<TIn, TOut> f)
        {
            var proxy = new CacheProxy<TIn, TOut>();
            proxy._f = f;

            return proxy;
        }
    }
}
