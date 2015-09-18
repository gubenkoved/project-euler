using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ArrayByValuesComparer<T> : IEqualityComparer<T[]>
    {
        public static ArrayByValuesComparer<T> Instance
        {
            get
            {
                return new ArrayByValuesComparer<T>();
            }
        }

        public bool Equals(T[] x, T[] y)
        {
            return Enumerable.SequenceEqual(x, y);
        }

        public int GetHashCode(T[] obj)
        {
            int hash = 0;
            for (int i = 0; i < obj.Length; i++)
            {
                hash ^= obj[i].GetHashCode();
            }

            return hash;
        }
    }
}
