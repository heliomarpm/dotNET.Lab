using System;

namespace Sample.AnaliseCombinatoria
{
    /// <summary>
    /// Uma combinação sem repetição, em análise combinatória, indica quantas variedades de subconjuntos diferentes
    /// com n elementos existem em um conjunto U , com r elementos. 
    /// Só é usada quando não há repetição de membros dentro do conjunto.
    /// Na combinação simples, a ordem dos elementos no agrupamento não interfere. 
    /// São arranjos que se diferenciam somente pela natureza de seus elementos.
    /// Portanto, se temos um conjunto A formado por n elementos tomados p a p, qualquer 
    /// subconjunto de A formado por p elementos será uma combinação, dada pela seguinte expressão:
    ///     C(n,p) = n!/((n-p)!*p!)
    /// </summary>
    public class Combination
    {
        public static void Run()
        {
            Console.WriteLine(Combine(3, 5));
            Console.WriteLine(GetBinCoeff(3, 5));
            //Console.WriteLine(GetnCk(3,5));
            Console.WriteLine(GetnCk2(3, 5));
            Console.WriteLine(BinomCoefficient(3, 5));
            Console.Read();
        }

        public static long Combine(long n, long k)
        {
            double sum = 0;
            for (long i = 0; i < k; i++)
            {
                sum += Math.Log10(n - i);
                sum -= Math.Log10(i + 1);
            }
            return (long)Math.Pow(10, sum);
        }

        public static long GetBinCoeff(long N, long K)
        {
            // This function gets the total number of unique combinations based upon N and K.
            // N is the total number of items.
            // K is the size of the group.
            // Total number of unique combinations = N! / ( K! (N - K)! ).
            // This function is less efficient, but is more likely to not overflow when N and K are large.
            // Taken from:  http://blog.plover.com/math/choose.html
            //
            long r = 1;
            long d;
            if (K > N) return 0;
            for (d = 1; d <= K; d++)
            {
                r *= N--;
                r /= d;
            }
            return r;
        }

        //public static long GetnCk(long n, long k)
        //{
        //    long bufferNum = 1;
        //    long bufferDenom = 1;

        //    for (long i = n; i > Math.Abs(n - k); i--)
        //    {
        //        bufferNum *= i;
        //    }

        //    for (long r = k; r => 1; r--)
        //    {
        //        bufferDenom *= r;
        //    }

        //    return (long)(bufferNum / bufferDenom);
        //}

        public static double GetnCk2(long n, long k)
        {
            double buffern = n * Math.Log(n) - n;
            double bufferk = k * Math.Log(k) - k;
            double bufferkn = Math.Abs(n - k) * Math.Log(Math.Abs(n - k)) - Math.Abs(n - k);

            return Math.Exp(buffern) / (Math.Exp(bufferk) * Math.Exp(bufferkn));
        }

        /// <summary>
        /// Calculates the binomial coefficient (nCk) (N items, choose k)
        /// </summary>
        /// <param name="n">the number items</param>
        /// <param name="k">the number to choose</param>
        /// <returns>the binomial coefficient</returns>
        public static long BinomCoefficient(long n, long k)
        {
            if (k > n) { return 0; }
            if (n == k) { return 1; } // only one way to chose when n == k
            if (k > n - k) { k = n - k; } // Everything is symmetric around n-k, so it is quicker to iterate over a smaller k than a larger one.
            long c = 1;
            for (long i = 1; i <= k; i++)
            {
                c *= n--;
                c /= i;
            }
            return c;
        }
    }
}
