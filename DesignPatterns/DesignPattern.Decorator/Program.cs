using System;

namespace Decorator
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

            Console.WriteLine("\n---- Begin Exemplo 01 --------------------");

            Pessoa pessoa;
            pessoa = new Pessoa();

            Console.WriteLine("usando Pessoa:");
            Console.WriteLine(pessoa.Andar());
            Console.WriteLine();

            PessoaRapida pessoaRapida;
            pessoaRapida = new PessoaRapida(pessoa);

            Console.WriteLine("usando PessoaRapida:");
            Console.WriteLine(pessoaRapida.Andar());
            Console.WriteLine(pessoaRapida.Correr());
            Console.WriteLine();

            PessoaLenta pessoaLenta;
            pessoaLenta = new PessoaLenta(pessoa);

            Console.WriteLine("usando PessoaLenta:");
            Console.WriteLine(pessoaLenta.Andar());
            Console.ReadKey();

            Console.WriteLine("\n---- End Exemplo 01   --------------------");

            Console.WriteLine("\n---- Begin Exemplo 02 --------------------");

            Sorvete s = new Sorvete();
            Console.WriteLine("Sorvete:");
            Console.WriteLine("{0:c}", s.Preco);
            Console.WriteLine();

            SorveteComCobertura c;
            c = new SorveteComCobertura(s);
            Console.WriteLine("Sorvete com cobertura:");
            Console.WriteLine("{0:c}", c.Preco);
            Console.WriteLine();

            SorveteComBala b;
            b = new SorveteComBala(s);
            Console.WriteLine("Sorvete com bala:");
            Console.WriteLine("{0:c}", b.Preco);
            Console.WriteLine();

            SorveteComCobertura cb;
            cb = new SorveteComCobertura(b);
            Console.WriteLine("Sorvete com cobertura & balas:");
            Console.WriteLine("{0:c}", cb.Preco);
            Console.ReadKey();

            Console.WriteLine("\n---- End Exemplo 02   --------------------");
        }
    }


}
