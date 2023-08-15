using System;

namespace Sample.AnaliseCombinatoria
{
    /// <summary>
    /// Na matemática, o fatorial (AO 1945: factorial) de um número natural n, representado por n!, é o produto de 
    /// todos os inteiros positivos menores ou iguais a n.
    /// 
    ///A notação n! foi introduzida por Christian Kramp em 1808.(Wikipédia)
    ///Considerando n um número natural maior que 1 (um), podemos definir como fatorial desse número n (n!) o número:
    ///
    ///     n! = n(n – 1)(n – 2)(n – 3) * ...* 3 * 2 * 1
    ///Lê-se n! como n fatorial ou fatorial de n.
    ///Veja alguns exemplos de cálculos de fatorial de um número :
    ///     5! = 5 * 4 * 3 * 2 * 1 = 120 
    ///     8! = 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1 = 40320 
    ///     6! = 6 * 5 * 4 * 3 * 2 * 1 = 720 
    ///     10! = 10 * 9 * 8 * 7 * 6 * 5 * 4 * 3 * 2 * 1 = 3.628.800
    /// </summary>
    public static class Factorial
    {
        public static void Run()
        {
            // Muda a cor das letras do console para amarelo.
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Exibe os resultados dos fatoriais de 0 à 20.
            for (int i = 1; i <= 20; i++)
            {
                // Mostra o fatorial e seu resultado.
                Console.WriteLine("{0} ! = {1}", i, Fatorial(i).ToString("#,#0"));
            }
            // Aguarda para sair.
            Console.ReadLine();
        }

        // Método calculador do fatorial.
        static long Fatorial(int number)
        {
            // Se o parâmetro (valor desejado para calculo do fatorial)
            // for 0 ou 1, o retorno sempre será 1 (devido a regra do fatorial).
            // Se for maior que 1, é feito o número vezes o fatorial desse mesmo número menos 1
            // até o parâmetro ser 1.
            // Isso é chamado de função recursiva / método recursivo / recursive function.
            if (number <= 1)
                return 1;
            else
                return number * Fatorial(number - 1);
        }

    }
}
