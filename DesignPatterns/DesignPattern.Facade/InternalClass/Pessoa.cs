using System;

namespace Facade
{
    //SubsystemA
    internal class Pessoa
    {
        internal void Ir(String paraOnde)
        {
            Console.WriteLine("chegou: {0}", paraOnde);
        }

        internal void PassarCartao()
        {
            Console.WriteLine("passou o cartão");
        }

        internal void DigitarSenha()
        {
            Console.WriteLine("digitou a senha");
        }

        internal void PegarDinheiro()
        {
            Console.WriteLine("pegou o dinheiro");
        }
    }
}
