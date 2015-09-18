using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Extenstions
    {
        public static string StringF(this object o, string format)
        {
            return string.Format(format, o);
        }

        public static string DumpString(this object o)
        {
            if (o is string)
            {
                return (string)o;
            }
            if (o is IEnumerable)
            {
                return string.Join(", ", ((IEnumerable)o).OfType<object>().Select(a => a.DumpString()));
            }
            
            return o.ToString();
        }

        public static void Dump(this object o, string label = null)
        {
            Console.WriteLine((label == null ? "" : label.StringF("[{0}] ")) + o.DumpString());
        }

        public static void DumpF(this object o, string format)
        {
            Console.WriteLine(string.Format(format, o.DumpString()));
        }

        public static void RunAndTime(this Action a, string label = null)
        {
            Stopwatch s = new Stopwatch();

            s.Start();

            a.Invoke();

            s.Stop();

            s.ElapsedMilliseconds.DumpF(( label != null ? label.StringF("[{0}] ") : "") + "{0} ms");
        }
    }
}
