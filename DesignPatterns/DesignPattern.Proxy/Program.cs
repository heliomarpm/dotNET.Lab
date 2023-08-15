using System;

namespace Proxy
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

            Console.WriteLine("\n----Exemplo 01------------------------------");
            Console.WriteLine("Sem proxy\n---------\n");

            for (int i = 1; i <= 3; i++)
            {
                Usuario usuario = new Usuario();

                Console.WriteLine(usuario.Consultar());
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Usando proxy para controlar a criação");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            IUsuario proxy;
            proxy = new UsuarioProxy();

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(proxy.Consultar());
                Console.WriteLine();
            }

            Console.ReadKey();

            Console.WriteLine("\n----Exemplo 02------------------------------");

            Console.WriteLine("Sem proxy\n---------\n");
            Usuario usuario2 = new Usuario();
            Console.WriteLine(usuario2.Consultar());
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Usando proxy para controlar acesso");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            UsuarioProxy2 proxy2 = new UsuarioProxy2();

            //tentando consultar sem autenticar
            Console.WriteLine(proxy2.Consultar());
            Console.WriteLine();

            //autenticando com senha incorreta            
            Console.WriteLine(proxy2.Autenticar("senhaErrada"));
            Console.WriteLine(proxy2.Consultar());
            Console.WriteLine();

            //agora, sim...            
            Console.WriteLine(proxy2.Autenticar("53NH4"));
            Console.WriteLine(proxy2.Consultar());
            Console.WriteLine();


            Console.ReadKey();
        }
    }





}