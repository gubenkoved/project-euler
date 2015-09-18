using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P58
{
    class Program
    {
        static void Main(string[] args)
        {
            //const long d = 29;
            //var r = Spiral(d); // to test

            //for (long y = 0; y < d; y++)
            //{
            //    for (long x = 0; x < d; x++)
            //    {
            //        Console.Write(string.Format("{0,4}", r[x, y]) + " ");
            //    }
            //    Console.WriteLine();
            //}
            //DiagonalNumbers(7).Dump();

            //return;

            Action solution = () =>
                {
                    long delta = 2;

                    for (long i = 3; true; i += delta)
                    {
                        //var d = Spiral(i);

                        //long dPrimesCount = CountDiagonalPrimes(i, d);

                        long[] diagonalNumbers = DiagonalNumbers(i);
                        long primesAmount = CountPrimes(diagonalNumbers);
                        double precentage = ((double)primesAmount) / diagonalNumbers.Length;

                        string.Format("Size {0}, percentage {1:P10}, {2}/{3}", i, precentage, primesAmount, diagonalNumbers.Length).Dump();

                        //dPrimes.OrderBy(q => q).Dump("diagonal");
                        //allPrimes.OrderBy(q => q).Dump("all");

                        // go back to find first falling under 0.1
                        if (precentage < 0.1)
                        {
                            i.Dump("Answer");
                            break;
                        }
                    }
                };

            solution.RunAndTime();
        }

        private static long CountPrimes(IEnumerable<long> values)
        {
            return values.Count(x => IsPrime(x));
        }

        //private static long CountDiagonalPrimes(long i, long[,] d)
        //{
        //    long dPrimesCount = 0;
        //    //List<long> dPrimes = new List<long>();
        //    for (long x = 0; x < i; x++)
        //    {
        //        if (IsPrime(d[x, x]))
        //        {
        //            dPrimesCount += 1;
        //            //dPrimes.Add(d[x, x]);
        //        }

        //        if (IsPrime(d[i - x - 1, x]))
        //        {
        //            dPrimesCount += 1;
        //            //dPrimes.Add(d[i - x - 1, x]);
        //        }
        //    }
        //    return dPrimesCount;
        //}

        public static long[] DiagonalNumbers(long len)
        {
            long[] result = new long[len * 2 - 1];

            long delta = 2;
            long step = 1;
            long current = 1;

            for (long i = 0; i < len * 2 - 1; i++)
            {
                result[i] = current;

                current += delta;

                if (step != 4)
                {
                    step += 1;
                } else
                {
                    delta += 2;
                    step = 1;
                }
            }

            return result;
        }

        //public static long[,] Spiral(long len)
        //{
        //    if (len % 2 == 0)
        //    {
        //        throw new NotSupportedException();
        //    }

        //    long x = len / 2;
        //    long y = x;

        //    bool yInc = false;
        //    bool xInc = true;
        //    bool goingHorizontaly = true;

        //    long d = 1;
        //    bool secondTurn = false;

        //    var r = new long[len, len];
        //    long currentValue = 1;

        //    do
        //    {
        //        for (long i = 0; i < d; i++)
        //        {
        //            r[x, y] = currentValue++;

        //            if (goingHorizontaly)
        //            {
        //                x += xInc ? +1 : -1;
        //            } else
        //            {
        //                y += yInc ? +1 : -1;
        //            }
        //        }

        //        if (goingHorizontaly)
        //        {
        //            xInc = !xInc;
        //        } else
        //        {
        //            yInc = !yInc;
        //        }

        //        goingHorizontaly = !goingHorizontaly;

        //        if (secondTurn)
        //        {
        //            d += 1;
        //            secondTurn = false;
        //        } else
        //        {
        //            secondTurn = true;
        //        }
        //    } while (currentValue < len * len);

        //    return r;
        //}

        public static bool[] _notPrime;
        public static bool IsPrime(long x)
        {
            if (_notPrime == null)
            {
                long max = 1000L * 1000L * 1000L;
                _notPrime = new bool[max];

                CalcEratosphenPrimes(max);
            }

            return !_notPrime[x];
        }

        public static void CalcEratosphenPrimes(long max)
        {
            _notPrime[1] = true;

            for (long i = 2; i < max; i++)
            {
                while (_notPrime[i])
                {
                    i += 1;

                    if (i >= max)
                    {
                        break;
                    }
                }

                for (long j = 2 * i; j < max; j += i)
                {
                    _notPrime[j] = true;
                }
            }

            "Eratosphen done".Dump();
        }
    }
}
