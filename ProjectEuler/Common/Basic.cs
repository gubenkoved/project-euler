using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Basic
    {
        /// <summary>
        /// Greatest common divisor.
        /// </summary>
        public static long GCD(long a, long b)
        {
            return (long)GCD_B(new BigInteger(a), new BigInteger(b));
        }

        /// <summary>
        /// Greatest common divisor.
        /// </summary>
        public static BigInteger GCD_B(BigInteger a, BigInteger b)
        {
            if (b == 0)
            {
                return a;
            } else
            {
                return GCD_B(b, a % b);
            }
        }

        /// <summary>
        /// Greatest common divisor.
        /// </summary>
        public static long LCM(long a, long b)
        {
            return (long)LCM_B(new BigInteger(a), new BigInteger(b));
        }

        /// <summary>
        /// Least common multiple.
        /// </summary>
        public static BigInteger LCM_B(BigInteger a, BigInteger b)
        {
            return a * b / GCD_B(a, b);
        }

        /// <summary>
        /// Returns sum of digits of given number.
        /// Example: 1234 -> 1+2+3+4 = 10
        /// </summary>
        public static int SumOfDigits(long x)
        {
            return SumOfDigits_B(new BigInteger(x));
        }

        /// <summary>
        /// Returns sum of digits of given number.
        /// Example: 1234 -> 1+2+3+4 = 10
        /// </summary>
        public static int SumOfDigits_B(BigInteger x)
        {
            int s = 0;
            while (x >= 10)
            {
                s += (int)(x % 10);

                x /= 10;
            }

            s += (int)x;

            return s;
        }

        /// <summary>
        /// Returns all divisors (not only prime) for given number.
        /// </summary>
        public static IEnumerable<long> ProperDivisors(long x)
        {
            for (long i = 1; i < x; i++)
            {
                if (x % i == 0)
                {
                    yield return i;
                }
            }
        }
    }
}
