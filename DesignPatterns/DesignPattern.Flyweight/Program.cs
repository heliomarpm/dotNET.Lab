using System;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            SanduicheFactory lista = new SanduicheFactory();

            Console.WriteLine("Pedido: {0}", lista[1]);
            Console.WriteLine("Pedido: {0}", lista[3]);
            Console.WriteLine("Pedido: {0}", lista[3]);
            Console.WriteLine("Pedido: {0}", lista[2]);
            Console.WriteLine("Pedido: {0}", lista[1]);
            Console.WriteLine("Pedido: {0}", lista[4]);

            Console.ReadKey();
        }
    }
}
