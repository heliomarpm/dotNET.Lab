using System;

namespace Facade
{
    //SubsystemA
    internal class SalaTreinamento
    {
        internal void AcenderLuzes()
        {
            Console.WriteLine("sala de treinamento - luzes acesas");
        }

        internal void ApagarLuzes()
        {
            Console.WriteLine("sala de treinamento - luzes apagadas");
        }

        internal void Abrir()
        {
            Console.WriteLine("sala de treinamento aberta");
        }

        internal void Fechar()
        {
            Console.WriteLine("sala de treinamento fechada");
        }
    }
}
