using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P99
{
    class Line
    {
        public int LineId;
        public int Num;
        public int Degree;

        public double Metric
        {
            get
            {
                return Math.Log10(Num) * Degree;
            }
        }
    }

    class Program
    {
        public static List<Line> Input = new List<Line>();

        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("p099_base_exp.txt"))
            {
                while (!r.EndOfStream)
                {
                    string s = r.ReadLine();

                    int[] nums = s.Split(',').Select(ss => int.Parse(ss)).ToArray();

                    Input.Add(new Line()
                    {
                        LineId = Input.Count + 1,
                        Num = nums[0],
                        Degree = nums[1],
                    });
                }
            }

            foreach(var l in Input.OrderBy(n => n.Metric))
            {
                Console.WriteLine(string.Format("#{0}, {1}^{2}, metric: {3}", l.LineId, l.Num, l.Degree, l.Metric));
            }
        }
    }
}
