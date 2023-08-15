using System;

namespace DesignPattern.ObserverII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Real World ****");
            SampleRealWorld.Run();

            Console.WriteLine("");
            Console.WriteLine("**** Structural ****");
            SampleStructural.Run();
        }
    }
}
