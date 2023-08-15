using System;

namespace Facade
{
    //SubsystemB
    internal class Carteira
    {
        internal void Abrir()
        {
            Console.WriteLine("carteira aberta");
        }

        internal void Fechar()
        {
            Console.WriteLine("carteira fechada");
        }

        internal void Pegar()
        {
            Console.WriteLine("carteira na mão");
        }

        internal void Guardar(String onde)
        {
            Console.WriteLine("carteira guardada: {0}", onde);
        }

        internal void PegarCartao(String qual)
        {
            Console.WriteLine("cartão na mão: {0}", qual);
        }

        internal void GuardarCartao()
        {
            Console.WriteLine("cartão na carteira");
        }
    }
}
