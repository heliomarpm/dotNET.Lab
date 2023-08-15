using System;
using System.Collections.Generic;

namespace Composite
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

            IObjeto arq1 = new Arquivo("composite.png");
            IObjeto arq2 = new Arquivo("minhaFoto.gif");
            IObjeto arq3 = new Arquivo("curriculum.docx");
            IObjeto pastaPrincipal = new Pasta("arquivos");
            IObjeto pasta1 = new Pasta("imagens");
            IObjeto pasta2 = new Pasta("office");

            pastaPrincipal.Adicionar(pasta1);
            pastaPrincipal.Adicionar(pasta2);
            pasta1.Adicionar(arq1);
            pasta1.Adicionar(arq2);
            pasta2.Adicionar(arq3);
            pasta2.Adicionar(new Arquivo("composite.pdf"));

            Console.WriteLine(pastaPrincipal);
            Console.ReadKey();
        }
    }

    //IComponent    
    interface IObjeto
    {
        string Nome { get; set; }
        int Nivel { get; set; }

        // Operation        
        void Adicionar(IObjeto o);
    }

    //Component (ou Leaf)    
    class Arquivo : IObjeto
    {
        public string Nome { get; set; }
        public int Nivel { get; set; }

        public Arquivo(String nome)
        {
            this.Nome = nome;
        }

        //Operation        
        public void Adicionar(IObjeto o)
        {
            Console.Write("não permitido");
        }

        //Operation        
        public override string ToString()
        {
            return String.Format("{0}{1}\n", new String(' ', this.Nivel), this.Nome);
        }
    }

    //Composite    
    class Pasta : IObjeto
    {
        //list : IComponent       
        List<IObjeto> conteudo;

        public string Nome { get; set; }
        public int Nivel { get; set; }

        public Pasta(String nome)
        {
            this.Nome = nome;
            this.conteudo = new List<IObjeto>();
        }

        //Operation        
        public void Adicionar(IObjeto o)
        {
            o.Nivel = this.Nivel + 3;
            this.conteudo.Add(o);
        }

        //Operation      
        public override string ToString()
        {
            String retorno = String.Format("{0}{1}\n", new String(' ', this.Nivel), this.Nome);

            foreach (var item in this.conteudo)
            {
                retorno += item;
            }

            return retorno;
        }
    }
}
