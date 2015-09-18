using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ConsoleUtilities
    {
        private const int width = 5;

        public static void ShowProgressBegin()
        {
            var progress = string.Format(string.Format("{{0,{0}:##0%}}", width), 0);

            Console.Write(progress);
        }

        public static void ShowProgress(double doneFraction)
        {
            var progress = string.Format(string.Format("{{0,{0}:##0%}}", width), doneFraction);

            Console.SetCursorPosition(Console.CursorLeft - width, Console.CursorTop);
            Console.Write(progress);
        }

        public static void ShowProgress(long done, long total)
        {
            ShowProgress(done / (total + 0.0));
        }
    }
}
