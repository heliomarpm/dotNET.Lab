using System;

#nullable enable
namespace Sample.UsandoClosedXml
{
    class Program
    {
        static void Main(string[] args)
        {
            string? test = null;

            Console.WriteLine(test);
#if DEBUG
#warning DEBUG is defined
#endif
            double valorRef = 2;
            Console.WriteLine(CalculateSquare(valorRef));
            Console.WriteLine(valorRef);

            Console.Read();
        }

        public static double CalculateSquare(in double value) => value * value;
    }
}
