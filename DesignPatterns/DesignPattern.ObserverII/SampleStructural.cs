using DesignPattern.ObserverII.Structural;
using System;

namespace DesignPattern.ObserverII
{
    public class SampleStructural
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Run()
        {
            // Configure Observer pattern
            ConcreteSubject s = new ConcreteSubject();

            Console.WriteLine("Anexando Observadores");
            Console.WriteLine();
            s.Attach(new ConcreteObserver(s, "ConcreteObserver X"));
            s.Attach(new ConcreteObserver(s, "ConcreteObserver Y"));
            s.Attach(new ConcreteObserver(s, "ConcreteObserver Z"));


            // Change subject and notify observers
            Console.WriteLine("Notificando Observadores");
            Console.WriteLine();

            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user
            Console.ReadKey();
        }

    }
}
