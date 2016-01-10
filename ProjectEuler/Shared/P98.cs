using ConsoleDump;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class P98
    {
        private static HashSet<long> _squareNumbers = new HashSet<long>();

        public static void Run()
        {
            foreach (var n in SquareNumbersGenerator(1000L * 1000 * 1000 * 10))
            {
                if (n.ToString().Length != n.ToString().Distinct().Count())
                {
                    continue;
                }

                _squareNumbers.Add(n);
            }

            //SquareNumbers(9).Dump();

            //return;

            var input = ParseInput();

            //input.OrderByDescending(x => x.Length).Dump();

            long largestSqNum = -1;

            foreach (var w1 in input)
            {
                foreach (var w2 in input)
                {
                    if (w1 == w2 || w1.CompareTo(w2) == 1)
                    {
                        continue;
                    }

                    if (IsAnagramm(w1, w2))
                    {
                        foreach (var sqNum in _squareNumbers.Where(x => x.ToString().Length == w1.Length).ToList())
                        {
                            long newNum = GetMapResult(w1, w2, sqNum.ToString());

                            if (sqNum.ToString().Length == newNum.ToString().Length
                                && _squareNumbers.Contains(newNum))
                            {
                                largestSqNum = Math.Max(largestSqNum, sqNum);
                                largestSqNum = Math.Max(largestSqNum, newNum);

                                $"{w1} - {w2} - {sqNum}".Dump();
                            }
                        }
                    }
                }
            }

            largestSqNum.Dump("Answer");

            //IsAnagramm("RACE", "CARE").Dump();
        }

        private static long GetMapResult(string w1, string w2, string numMap)
        {
            if (w1.Length != numMap.Length
                || w1.Length != w2.Length)
            {
                throw new InvalidOperationException();
            }

            var dic = new Dictionary<char, char>();

            int n = w1.Length;

            for (int i = 0; i < n; i++)
            {
                dic[w1[i]] = numMap[i];
            }

            string result = "";

            for (int i = 0; i < n; i++)
            {
                result += dic[w2[i]];
            }

            return long.Parse(result);
        }

        private static IEnumerable<string> ParseInput()
        {
            using (var r = new StreamReader("data/p098_words.txt"))
            {
                return r.ReadLine().Split(',').Select(s => s.TrimStart('\"').TrimEnd('\"')).ToList();
            }
        }

        private static bool IsAnagramm(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            var dic = new Dictionary<char, int>();

            foreach (var ch in a)
            {
                if (!dic.ContainsKey(ch))
                {
                    dic[ch] = 0;
                }

                dic[ch] += 1;
            }

            foreach (var ch in b)
            {
                if (!dic.ContainsKey(ch) || dic[ch] <= 0)
                {
                    return false;
                } else
                {
                    dic[ch] -= 1;
                }
            }

            return true;
        }

        private static IEnumerable<long> SquareNumbersGenerator(long max )
        {
            long i = 1;
            long c;

            do
            {
                c = i * i;

                i += 1;

                yield return c;
            } while (c < max);
        }
    }
}
