using Pattern.ChainOfResponsability;
using System;

namespace DesignPattern.ChainOfResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Aprovar larry = new Diretor();
            Aprovar sam = new VicePresidente();
            Aprovar tammy = new Presidente();

            larry.SetSucessor(sam);
            sam.SetSucessor(tammy);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Recursos");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            Console.ReadKey();
        }
    }
}
