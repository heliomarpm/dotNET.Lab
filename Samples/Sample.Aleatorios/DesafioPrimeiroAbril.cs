using System;

namespace Sample.Aleatorios
{
    public class DesafioPrimeiroAbril
    {
        public static void Run()
        {

            Console.WriteLine("Desafio: Primeiro de Abril\n\n");
            Console.WriteLine("Quatro pessoas que gostam de pregar peças decidiram\n");
            Console.WriteLine("tornar o primeiro de abril inesquecível, ou seja, com muitas brincadeiras.\n\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Cada um pregou uma peça numa vítima diferente usando um objeto inofensivo.\n");

            Console.WriteLine("Nome:{0}{0}{2}{1}Sobrenome:{0}{3}{1}Brincadeira:{0}{4}{1}Vítima:{0}{0}{5}{1}",
                              "\t", "\n",
                              "Ana, Ester, Pablo, Rodolfo",
                              "Fontes, Levis, Matoso, Salgado",
                              "Almofada de barulho, Aranha falsa, Foto alterada, Mosca falsa",
                              "Irmão, Mãe, Pai, Tia");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("«« DICAS »»\n\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1 - Ana deu risadas enquanto colocava uma aranha falsa na comida de sua vítima.\n");
            Console.WriteLine("2 - A pessoa de sobrenome Salgado (que não é Ana) pregou uma peça em seu irmão.\n");
            Console.WriteLine("3 - A pessoa de sobrenome Matoso colocou uma almofada de barulho na cadeira de sua vítima.\n");
            Console.WriteLine("4 - Rodolfo pregou uma peça em sua tia, mas não foi ele que usou a almofada de barulho.\n");
            Console.WriteLine("5 - A brincadeira feita por Levis incluía uma mosca falsa. A vítima de Ester foi seu pai.\n");





            Console.Read();
        }
    }
}
