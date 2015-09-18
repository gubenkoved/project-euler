using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ContinuedFraction
    {
        public long a0;
        public long[] a;

        private ContinuedFraction()
        {
        }

        public static ContinuedFraction Create(long a0, params long[] a)
        {
            return new ContinuedFraction()
            {
                a0 = a0,
                a = a,
            };
        }

        public Fraction Evaluate()
        {
            if (a.Count() == 0)
            {
                return Fraction.Create(a0);
            }

            var r = Fraction.Create(a.Last());

            for (int i = a.Length - 1 - 1; i >= 0; i--)
            {
                r = Fraction.Create(1) / r + Fraction.Create(a[i]);
            }

            r = Fraction.Create(a0) + Fraction.Create(1) / r;

            return r;
        }
    }
}
