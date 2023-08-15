using System;

namespace Facade
{
    //SubsystemB
    internal class Projetor
    {
        internal void Ligar()
        {
            Console.WriteLine("projetor ligado");
        }

        internal void Desligar()
        {
            Console.WriteLine("projetor desligado");
        }
    }
}
