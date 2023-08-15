using System;
using System.Threading;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n---- Begin Exemplo 01 --------------------");
            HomemFacade.SacarDinheiro();
            Console.WriteLine("\n---- End Exemplo 01   --------------------");

            Console.WriteLine("\n---- Begin Exemplo 02 --------------------");

            Sala s = new Sala();

            s.Abrir();

            Console.WriteLine("------------------------");
            Console.WriteLine("a aula está em andamento");
            Console.WriteLine("  a g u a r d e  . . .");
            Console.WriteLine("------------------------");

            Thread.Sleep(5000);

            s.Fechar();
            Console.WriteLine("\n---- End Exemplo 02   --------------------");

            Console.ReadKey();
        }
    }
}
