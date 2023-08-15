using System;
using System.Collections.Generic;

namespace Sample.Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario u1 = new Usuario("Heliomar", "M");
            Usuario u2 = new Usuario("Angelina", "F");
            Usuario u3 = new Usuario("Lázaro", "M");
            Usuario u4 = new Usuario("Laura", "F");

            Console.WriteLine("\nGeneric List >>>>>>>");

            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario("Heliomar", "H"));
            usuarios.Add(new Usuario("Angelina", "A"));
            usuarios.Add(new Usuario("Lázaro", "L"));
            usuarios.Add(new Usuario("Laura", "L"));

            Console.WriteLine("\nForeach na Lista de Usuario");

            foreach (var item in usuarios)
            {
                Console.WriteLine("Nome: " + item.Nome);
            }


            IEnumerator<Usuario> enumer = usuarios.GetEnumerator();

            Console.WriteLine("\nForeach no metodo GetEnumerator da lista de usuario");

            while (enumer.MoveNext())
            {
                Console.WriteLine("Nome: " + enumer.Current.Nome);
            }

            Console.WriteLine("\nClass UsuarioCollection >>>>>>>");
            UsuarioCollection uc = new UsuarioCollection();
            uc.Add(u1);
            uc.Add(u2);
            uc.Add(u3);
            uc.Add(u4);

            //uc.Add("Marques"); // Erro em tempo de compilação

            Console.WriteLine("Usuario Index 0: " + uc[0].Nome);

            foreach (Usuario u in uc)
            {
                Console.WriteLine(u.ToString());
            }


            Console.WriteLine("\nClass GenericClassWithWhere >>>>>>>");

            GenericClassWithWhere<Usuario> gu = new GenericClassWithWhere<Usuario>();
            gu.Entidade = u1;

            Console.WriteLine(gu.Entidade.ToString());


            Console.WriteLine("\nClass GenericClass >>>>>>>");

            GenericClass<int> t1 = new GenericClass<int>();
            t1.Valor = 10;
            Console.WriteLine("Inteiro: " + t1.Valor);

            GenericClass<string> t2 = new GenericClass<string>();
            t2.Valor = "CON-2147";
            Console.WriteLine("String: " + t2.Valor);


            Console.WriteLine("\nClass GenericHeranca<Usuario> >>>>>>>");
            GenericHeranca<Usuario> gh = new GenericHeranca<Usuario>();
            gh.Nome = u2.Nome;
            gh.Sexo = u2.Sexo;
            gh.Idade = 25;

            Console.WriteLine(gh.ToString());

            Console.WriteLine("\nClass UsuarioHeranca >>>>>>>");
            UsuarioHeranca uh = new UsuarioHeranca();
            uh.Nome = u3.Nome;
            uh.Sexo = u3.Sexo;
            uh.Idade = 7;

            Console.WriteLine(uh.ToString());

            Console.WriteLine("\nPressione alguma tecla para fechar");
            Console.ReadKey();
        }
    }
}
