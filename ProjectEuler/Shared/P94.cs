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
        public const long MAX_PERIMETER = 1000 * 1000 * 1000; //1000 * 1000 * 1000;

        public static void Run()
        {
            long r = 0;
            long maxSide = (long)Math.Ceiling((MAX_PERIMETER / 3.0) + 1);
            
            // skip where perimeter is odd
            for (long a = 3; a < maxSide; a += 2)
            {
                if (a % 100000 == 1)
                {
                    (a / (float)maxSide).Dump();
                }

                long b = a;

                long c1 = a - 1;
                long c2 = a + 1;

                long p1 = a + b + c1;
                long p2 = a + b + c2;

                if (IsAlmostEquilateral(a, b, c1) && p1 < MAX_PERIMETER)
                {
                    r += (a + b + c1);

                    $"{a}, {b}, {c1}".Dump();

                    a *= 3;
                }

                if (IsAlmostEquilateral(a, b, c2) && p2 < MAX_PERIMETER)
                {
                    r += (a + b + c2);

                    $"{a}, {b}, {c2}".Dump();

                    a *= 3;
                }
            }

            r.Dump("answer");
        }

        public static bool IsAlmostEquilateral(long a, long b, long c)
        {
            /*if ((a + b + c) % 2 != 0)
            {
                return false;
            }*/

            long cSq = c*c;

            long rem;

            long cSqDiv = Math.DivRem(cSq, 4, out rem);

            if (rem != 0)
            {
                return false;
            }

            long underSq = a * a - cSqDiv;

            //long p = (a + b + c) >> 1;

            //long underSq = p * (p - a) * (p - b) * (p - c);

            long? root = IsPerfectSquare3(underSq);

            return root != null;
        }

        public static long? IsPerfectSquare3(long n)
        {
            long a = (long)Math.Sqrt(n);
            if(a * a == n)
            {
                return a;
            }

            return null;
        }

        public static long? IsPerfectSquare2(long a)
        {
            // using newton method

            long xPrev = a;
            long xCur;

            while (true)
            {
                 xCur = (xPrev + a / xPrev) / 2;

                if (xCur == xPrev || Math.Abs(xCur - xPrev) <= 1)
                {
                    break;
                }

                xPrev = xCur;
            }

            if (xCur * xCur == a)
            {
                return xCur;
            }
            else
            {
                return null;
            }
        }

        public static long? IsPerfectSquare(long x)
        {
            long l = 1;
            long h = x;

            while (true)
            {
                long c = (l + h) >> 1;
                long p = c * c;

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
