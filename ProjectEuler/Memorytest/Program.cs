using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memorytest
{
    class Program
    {
        public static List<byte[]> data = new List<byte[]>();

        static void Main(string[] args)
        {
            int mb = 0;
            for (int i = 0; i < 100000; i++)
            {
                var d = new byte[1024 * 1024];

                InitArray(d);

                data.Add(d);

                mb += 1;

                Console.WriteLine(mb);

                Thread.Sleep(1);
            }

            Console.WriteLine(data[100][100]);
        }

        static public void InitArray(byte[] a)
        {
            byte n = 1;
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = n++;
            }
        }
    }
}
