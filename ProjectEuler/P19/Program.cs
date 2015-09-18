using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P19
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(1901, 1, 1);

            int sundays = 0;

            do
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday
                    && dt.Day == 1)
                {
                    sundays += 1;

                    Console.Write("+ ");
                    Console.WriteLine(dt.ToLongDateString());
                } else
                {
                    //Console.WriteLine(dt.ToLongDateString());
                }

                dt = dt.AddDays(1);

                

            } while (dt.Year != 2001);

            Console.WriteLine(sundays);
        }
    }
}
