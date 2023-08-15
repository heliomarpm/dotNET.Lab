using System;
using System.Threading;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (System.IO.File.Exists("Leiame.txt"))
            {
                string[] linhas = System.IO.File.ReadAllLines(@"Leiame.txt");

                foreach (var linha in linhas)
                {
                    if (linha.StartsWith("\t"))
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                    Console.WriteLine(linha);
                }
                Console.WriteLine(new String('=', 100));
                Console.WriteLine();
                Console.WriteLine();
                Console.ResetColor();
            }

            IAparelho a = new Liquidificador();

            Console.WriteLine(a.On());
            Console.WriteLine(a.Off());

            Console.WriteLine();

            a = new Lavadora();

            Console.WriteLine(a.On());

            Console.ReadKey();
        }
    }

    //Adaptee
    class TomadaABNT
    {
        //SpecificRequest
        private bool ligado;
        public bool Ligado
        {
            get
            {
                return this.ligado;
            }
            set
            {
                this.ligado = value;
                Console.WriteLine(">>> {0}ligando", this.ligado ? "" : "des");
            }
        }
    }

    //ITarget
    interface IAparelho
    {
        //Request
        String On();

        //Request
        String Off();
    }

    //Adapter
    class Liquidificador : TomadaABNT, IAparelho
    {
        //Request
        public String On()
        {
            this.Ligado = true;

            return "o liquidificador está ligado";
        }

        //Request
        public String Off()
        {
            this.Ligado = false;

            return "o liquidificador está desligado";
        }
    }

    class Lavadora : TomadaABNT, IAparelho
    {
        //Request
        public String On()
        {
            this.Ligado = true;

            Console.WriteLine("a lavadora está lavando roupas");

            this.Lavar();
            this.Centrifugar();

            this.Enxaguar();
            this.Centrifugar();

            this.Enxaguar();
            this.Centrifugar();

            return this.Off();
        }

        //Request
        public String Off()
        {
            this.Ligado = false;
            return "agora a lavadora está desligada";
        }

        public void Lavar()
        {
            Console.WriteLine("\tadicionando água e sabão em pó...");
            Thread.Sleep(2000);
            Console.WriteLine("\tlavando...");
        }

        private void Enxaguar()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\tenxaguando...");
        }

        private void Centrifugar()
        {
            Thread.Sleep(1000);
            Console.WriteLine("\tcentrifugando...");
        }
    }
}