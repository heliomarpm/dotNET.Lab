using System;

namespace Encapsulamento
{
    class Program
    {
        static void Main(string[] args)
        {
            Retangulo retangulo = new Retangulo()
            {
                Largura = 3,
                Altura = 2
            };

            Console.WriteLine("largura = {0}, altura = {1}, área = {2}", retangulo.Largura, retangulo.Altura, retangulo.Area);
            Console.ReadKey();
        }
    }

    class Retangulo
    {
        private UInt32 largura;
        public UInt32 Largura
        {
            get { return largura; }
            set
            {
                largura = value;
                this.CalcularArea();
            }
        }

        private UInt32 altura;
        public UInt32 Altura
        {
            get { return altura; }
            set
            {
                altura = value;
                this.CalcularArea();
            }
        }

        public UInt64 Area { get; private set; }

        private void CalcularArea()
        {
            this.Area = this.largura * this.altura;
        }
    }
}
