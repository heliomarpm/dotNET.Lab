using DesignPattern.ObserverII.RealWord;
using System;

namespace DesignPattern.ObserverII
{
    public class SampleRealWorld
    {/// <summary>
     /// Entry point into console application.
     /// </summary>
        public static void Run()
        {
            // Create IBM stock and attach investors
            IBM ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investidor("Investidor 001"));
            ibm.Attach(new Investidor("Investidor 002"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // Wait for user
            Console.ReadKey();
        }

    }
}
