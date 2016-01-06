using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class P94
    {
        public const int MAX_PERIMETER = 1000 * 1000 * 1000; //1000 * 1000 * 1000;

        public static void Run()
        {
            BigInteger r = 0;
            int maxSide = (int)Math.Ceiling((MAX_PERIMETER / 3.0) + 1);
            
            for (int a = 2; a < maxSide; a++)
            {
                if (a % 100000 == 0)
                {
                    (a / (float)maxSide).Dump();
                }

                int b = a;

                int c1 = a - 1;
                int c2 = a + 1;

                int p1 = a + b + c1;
                int p2 = a + b + c2;

                if (IsAlmostEquilateral(a, b, c1) && p1 < MAX_PERIMETER)
                {
                    r += (a + b + c1);

                    $"{a}, {b}, {c1}".Dump();
                }

                if (IsAlmostEquilateral(a, b, c2) && p2 < MAX_PERIMETER)
                {
                    r += (a + b + c2);

                    $"{a}, {b}, {c2}".Dump();
                }
            }

            r.Dump("answer");
        }

        public static bool IsAlmostEquilateral(int a, int b, int c)
        {
            BigInteger p = a + b + c;

            BigInteger underSq = p * (p - 2 * a) * (p - 2 * b) * (p - 2 * c);

            BigInteger? root = IsPerfectSquare(underSq);

            return root != null
                && BigInteger.Remainder(root.Value, 4) == 0;

        }

        public static BigInteger? IsPerfectSquare(BigInteger x)
        {
            BigInteger l = 1;
            BigInteger h = x;

            while (true)
            {
                BigInteger c = (l + h) >> 1;
                BigInteger p = BigInteger.Pow(c, 2);

                if (p == x)
                {
                    return c;
                }

                if (l == h)
                {
                    break;
                }

                if (p > x)
                {
                    h = c;
                } else
                {
                    if (l == c)
                    {
                        l = c + 1;
                    }
                    else
                    {
                        l = c;
                    }
                }
            }

            return null;
        }
    }
}
