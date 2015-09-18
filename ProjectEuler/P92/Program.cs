using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDump;


namespace P92
{
    class Program
    {
        static void Main(string[] args)
        {
            int count89 = 0;

            foreach (var start in Enumerable.Range(1, (int)Math.Pow(10, 7)))
            {
                int end = IsIt89Or1(SquareChain(start));

                if (end == 89)
                {
                    count89 += 1;
                }

                //new
                //{
                //    start = start,
                //    end = end,
                //    seq = string.Join(",", used),
                //}.Dump();

                if (start % (1000 * 1000) == 0)
                {
                    "+".Dump();
                }
            }

            count89.Dump("Answer");
        }

        static int IsIt89Or1(IEnumerable<int> seq)
        {
            foreach (var current in seq)
            {
                if (current == 1)
                {
                    return 1;
                } else if (current == 89)
                {
                    return 89;
                }
            }

            throw new Exception("Will never get there");
        }

        static IEnumerable<int> SquareChain(int start)
        {
            int cur = start;

            while(true)
            {
                yield return cur;

                cur = SquareDigitsSum(cur);
            }
        }

        static int SquareDigitsSum(int n)
        {
            int sumOfDigitSquares = 0;
            
            while (n != 0)
            {
                int d = n % 10;

                sumOfDigitSquares += d * d;

                n = n / 10;
            }

            return sumOfDigitSquares;
        }
    }
}
