using System;
using System.Collections.Generic;

namespace DesignPattern.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ERobos> Robos = new List<ERobos> { ERobos.C6PO, ERobos.Bumblebee, ERobos.Optimus_Prime };

            RoboAbstract robo1;


            Robos.ForEach(delegate (ERobos R)
            {
                robo1 = RoboFactory.Criar(R);
                robo1.Script(0);
                robo1.Transformar();
                robo1.Script(1);
                robo1.Script(2);
                robo1.Script(3);
                robo1.Transformar();

                Console.WriteLine();
            });


            Console.ReadKey();

        }
    }






}
