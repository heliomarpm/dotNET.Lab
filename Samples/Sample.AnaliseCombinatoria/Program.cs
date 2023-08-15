using System;
using System.Diagnostics;

namespace Sample.AnaliseCombinatoria
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Board.Instance.Carregar(9);

            watch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = watch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey();
            return;
            Combination.Run();
            Factorial.Run();
            Permutation.Run();
        }
    }
}
