using System;

namespace Facade
{

    //SubsystemC
    internal class Computador
    {
        internal void Ligar()
        {
            Console.WriteLine("computador ligado");
        }

        internal void Desligar()
        {
            Console.WriteLine("computador desligado");
        }
    }
}
