using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P42
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>();
            using (var reader = new StreamReader("p042_words.txt"))
            {
                string content = reader.ReadToEnd();

                string[] wordsRaw = content.Split(',');

                foreach (var item in wordsRaw)
                {
                    words.Add(item.Trim('\"'));
                }
            }

            int amount = 0;
            foreach (var word in words)
            {
                string.Format("{0, 20} {1}", word, WordSum(word)).Dump();

                if (IsTriangle(WordSum(word)))
                {
                    amount += 1;
                }
            }

            Console.WriteLine(amount);
        }

        public static int WordSum(string s)
        {
            int r = 0;
            foreach (var c in s)
            {
                r += (int)c - (int)'A' + 1;
            }

            return r;
        }

        public static bool IsTriangle(int n)
        {
            var t = TriangleNums().TakeWhile(x => x <= n);

            return t.Contains(n);
        }

        public static IEnumerable<int> TriangleNums()
        {
            int n = 0;
            while (true)
            {
                yield return (n + 1) * n / 2;

                n += 1;
            }

        }
    }
}
