using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Aleatorios
{
    /// <summary>
    /// Referencias:
    /// </summary>
    /// <urls>
    /// http://blog.lambda3.com.br/2010/06/porque-eu-adoro-c-yield/
    /// http://www.rafaelalmeida.net/POST/c_o_poder_do_yield_return
    /// http://elemarjr.net/2012/03/03/laziness-como-yield-keywords-funcionam/
    /// </urls>
    public class YieldReturnSample
    {

        public static void Run()
        {
            Console.Title = "Lazy demo";
            var values = GetNumbers();
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();

            var nums = GetNums(2, 5);

            Console.WriteLine("nums.Count() = {0}", nums.Count());

            //Assert.AreEqual(4, nums.Count());
            //Assert.IsTrue(nums.Contains(2));

            var pow = Power(2, 5);

            Console.WriteLine("pow.Count() = {0}", pow.Count());
            foreach (var item in pow)
            {
                Console.WriteLine("pow = {0}", item);
            }

            var words = GetWordsUpper("test yield return\n");
            Console.WriteLine(words);
            Console.WriteLine("words.Count() = {0}", words.Count());

            foreach (var item in words)
            {
                Console.WriteLine("word = {0}", item);
            }

            Console.Read();

            Console.WriteLine("\n<<< Testando o tempo de processamento do yield >>>");

            int val = 0;
            DateTime dt;

            do
            {
                Console.WriteLine("Informe novo valor para teste:");
                val = Console.Read();

                Console.WriteLine(val);
            } while (val > 0);
            return;

            while (val > 0)
            {
                Console.WriteLine("\n\nUsando List de {0} posicoes.", val);

                dt = DateTime.Now;
                var t1 = GetNums2(1, val);
                Console.WriteLine("Carregado em: " + DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000000") + " segundos");

                dt = DateTime.Now;
                foreach (var item in t1)
                { }
                Console.WriteLine("Percorrido em: " + DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000000") + " segundos");

                Console.WriteLine("\n\nUsando Yield de {0} posicoes.", val);
                dt = DateTime.Now;
                var t2 = GetNums(1, val);
                Console.WriteLine("Carregado em: " + DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000000") + " segundos");

                dt = DateTime.Now;
                foreach (var item in t1)
                { }
                Console.WriteLine("Percorrido em: " + DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000000") + " segundos");

                Console.WriteLine("Informe novo valor para teste:");
                val = Console.Read();
            }

            Console.Read();
        }
        public static IEnumerable<int> GetNums2(int from, int to)
        {
            List<int> ret = new List<int>();

            for (int i = from; i < to; i++)
            {
                ret.Add(i);
            }

            return ret;
        }

        public static IEnumerable<int> GetNums(int from, int to)
        {
            for (int i = from; i <= to; i++)
                yield return i;
        }

        public static IEnumerable<int> Power(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }

        public static IEnumerable<string> GetWordsUpper(string phrase)
        {
            foreach (var word in phrase.Split(' '))
            {
                yield return word.ToUpper();
            }
        }

        static IEnumerable<int> GetNumbers()
        {
            Console.WriteLine("Returning 1");
            yield return 1;
            Console.WriteLine("Returning 2");
            yield return 2;
            Console.WriteLine("Returning 3");
            yield return 3;
            Console.WriteLine("Returning 4");
            yield return 4;
        }
    }
}
