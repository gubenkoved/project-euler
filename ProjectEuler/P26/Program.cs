using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using System.Numerics;

namespace P26
{
    class Program
    {
        static void Main(string[] args)
        {
            const int pow = 5000;

            string longestTemplate = "";
            int answer = -1;

            for (BigInteger i = 2; i < 1000; i++)
            {
                BigInteger d = BigInteger.Pow(10, pow);

                BigInteger x = d / i;

                int zeroCount = pow - x.ToString().Length;

                string s = "0." + new string(Enumerable.Repeat('0', zeroCount).ToArray()) + x.ToString();

                int templateStartsFrom;
                string template = FindTemplate(s, out templateStartsFrom);

                string r = s.Substring(0, templateStartsFrom);

                if (template != "0")
                {
                    r += "(" + template + ")";
                }

                if (template.Length > longestTemplate.Length)
                {
                    longestTemplate = template;

                    answer = (int)i;
                }

                string.Format("1/{0,4} = {2}", i, s, r).Dump();
            }

            answer.Dump("answer");
            longestTemplate.Dump("longest template");
            longestTemplate.Length.Dump("longest template len");
        }

         //0.1666666666666666 -> 0.1(6), max width = 1
         //0.114545454545454 -> 0.11(45), max width = 2
        static string FindTemplate(string s, out int startFrom)
        {
            for (int width = 1; width < s.Length; width++)
            {
                for (startFrom = 0; startFrom < s.Length - width; startFrom++)
                {
                    if (startFrom >= 20)
                    {
                        break;
                    }

                    string t = s.Substring(startFrom, width);
                    if (IsTemplateMatch(s, t, startFrom))
                    {
                        return t;
                    }
                }
            }

            throw new InvalidOperationException();
        }

        static bool IsTemplateMatch(string s, string template, int startFrom)
        {
            for (int i = startFrom; i < s.Length; i++)
            {
                if (s[i] != template[(i - startFrom) % template.Length])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
