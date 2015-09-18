using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


using Common;

namespace P63
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int power = 1;
            bool found;

            do
            {
                found = false;

                for (int d = 1; d < 10; d++)
                {
                    if (BigInteger.Pow(d, power).ToString().Length == power)
                    {
                        count += 1;

                        found = true;
                    }
                }

                power += 1;
            } while (found);

            count.Dump("Solution");
            power.Dump("Last power with such property");
        }
    }
}
