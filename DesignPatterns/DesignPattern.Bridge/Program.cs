using System;

namespace Bridge
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

            Console.WriteLine("\n------------- Exemplo 01");

            CalculadoraFramework cf = new CalculadoraFramework();
            CalculadoraJohnWallis jw = new CalculadoraJohnWallis();
            CalculadoraLeibniz lz = new CalculadoraLeibniz();

            Console.WriteLine("constante do framework");
            Console.WriteLine("\tPI: {0}\n", new Calculadora(cf).PI);
            Console.WriteLine("algoritmo de John Wallis");
            Console.WriteLine("\tPI: {0}\n", new Calculadora(jw).PI);
            Console.WriteLine("algoritmo de Leibniz");
            Console.WriteLine("\tPI: {0}\n", new Calculadora(lz).PI);
            Console.ReadKey();


            Console.WriteLine("\n------------- Exemplo 02");
            //usando Generic
            Console.WriteLine("constante do framework");
            Console.WriteLine("\tPI: {0}\n", new CalculadoraGeneric<CalculadoraFramework>().PI);
            Console.WriteLine("algoritmo de John Wallis");
            Console.WriteLine("\tPI: {0}\n", new CalculadoraGeneric<CalculadoraJohnWallis>().PI);
            Console.WriteLine("algoritmo de Leibniz");
            Console.WriteLine("\tPI: {0}\n", new CalculadoraGeneric<CalculadoraLeibniz>().PI);
            Console.ReadKey();
        }
    }

    //Bridge    
    interface ICalculadora
    {
        //OperationImp        
        double PI { get; }
    }

    //ImplementationA    
    class CalculadoraFramework : ICalculadora
    {
        //retorna a constante PI da classe Math
        //OperationImp        
        public double PI { get { return Math.PI; } }
    }


    //ImplementationB    
    class CalculadoraJohnWallis : ICalculadora
    {
        //OperationImp        
        public double PI
        {
            get
            {
                double pi = 1;
                for (int i = 1; i <= 100000; i++)
                {
                    double numero = i * 2;
                    pi *= numero / (numero - 1);
                    pi *= numero / (numero + 1);
                }

                return 2 * pi;
            }
        }
    }


    //ImplementationX    
    class CalculadoraLeibniz : ICalculadora
    {
        //OperationImp        
        public double PI
        {
            get
            {
                double pi = 0;

                for (int i = 1; i <= 400000; i += 4)
                {
                    pi = pi + 1.0 / i - 1.0 / (i + 2);
                }

                return 4 * pi;
            }
        }
    }



    //Abstraction    
    class Calculadora
    {
        //bridge        
        ICalculadora c;

        public Calculadora(ICalculadora c)
        {
            this.c = c;
        }

        //Operation        
        public double PI
        {
            get
            {
                return c.PI;
            }
        }
    }


    //Abstraction usando Generic    
    class CalculadoraGeneric<T> where T : ICalculadora, new()
    {
        //Operation        
        public double PI
        {
            get
            {
                //bridge >>> new T()                
                return new T().PI;
            }
        }
    }
}
