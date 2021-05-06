using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConcatBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Enumerable.Repeat(new string('A', 10000), 100000).ToArray();

            Stopwatch stopWatchConcat = new Stopwatch();
            stopWatchConcat.Start();
            string concat = String.Concat(strings);
            stopWatchConcat.Stop();
            TimeSpan timeConcat = stopWatchConcat.Elapsed;
            Console.WriteLine("Concat: " + String.Format("{0:00}.{1:00}s", timeConcat.TotalSeconds, timeConcat.Milliseconds));
            // 


            Stopwatch stopWatchJoin = new Stopwatch();
            stopWatchJoin.Start();
            string join = String.Join("", strings);
            stopWatchJoin.Stop();
            TimeSpan timeJoin = stopWatchJoin.Elapsed;
            Console.WriteLine("Join: " + String.Format("{0:00}.{1:00}s", timeJoin.TotalSeconds, timeJoin.Milliseconds));

            Stopwatch stopWatchBuilder = new Stopwatch();
            stopWatchBuilder.Start();
            string builder = new StringBuilder().AppendJoin("", strings).ToString();
            stopWatchBuilder.Stop();
            TimeSpan timeBuilder = stopWatchBuilder.Elapsed;
            Console.WriteLine("Builder: " + String.Format("{0:00}.{1:00}s", timeBuilder.TotalSeconds, timeBuilder.Milliseconds));

            Debug.Assert(concat.Equals(join));
            Debug.Assert(join.Equals(builder));
            // Локально:
            // Concat: 01.548s
            // Join: 01.564s
            // Builder: 01.230s
        }
    }
}
