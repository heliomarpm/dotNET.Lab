using Sample.Extensions.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = { 1, 2, 3, 4, 5 };

            var a = data.Where(i => i % 2 == 0);

            Console.WriteLine("Multiplos de 2 (Extension Where padrão)");
            foreach (var item in a)
                Console.WriteLine(item);


            var b = data.MyWhere<int>(i => i % 2 == 0);

            Console.WriteLine("Multiplos de 2 (Extension MyWhere )");
            foreach (var item in b)
                Console.WriteLine(item);



            IEnumerable itens = new[] { new { A = "abc", B = 100 }, new { A = "def", B = 200 }, new { A = "ghi", B = 300 } };

            var typed = itens.Cast(() => new { A = default(string), B = default(int) });

            foreach (var item in typed)
            {
                Console.WriteLine(item.A);
                Console.WriteLine(item.B);
            }


            List<int> BigList = new List<int>() { 1, 2, 3, 4, 5, 11, 12, 13, 14, 15 };
            IEnumerable<int> Smalllist = BigList.MyMethod();
            foreach (int v in Smalllist)
                Console.WriteLine(v);

            Console.ReadKey();
        }
    }


    public class TestCast
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

namespace Sample.Extensions.Extensions
{
    public static class ValidateExtension
    {
        public static bool IsNull(this string pValue)
        {
            return (string.IsNullOrEmpty(pValue) || pValue.ToString().Trim().Length == 0);
        }

        public static bool IsNull(this DateTime pValue)
        {
            return (pValue == null || pValue.Equals(default(DateTime)) || pValue.Equals(new DateTime(1900, 1, 1)));
        }

        public static string IfNull(this string pValue, string pDefaultValue)
        {
            return (pValue == null ? pDefaultValue : pValue);
        }

        public static DateTime IfNull(this DateTime pValue, DateTime pDefaultValue)
        {
            bool bNull = (pValue == null || pValue.Equals(default(DateTime)));

            return (bNull ? pDefaultValue : pValue);
        }
    }

    public static class EnumerableExtension
    {
        public static IEnumerable<T> MyMethod<T>(this IEnumerable<T> Container)
        {
            int Count = 1;

            foreach (T Element in Container)
            {
                if ((Count++ % 2) == 0)
                    yield return Element;
            }
        }

        // note that the template is not used, and we never need to pass one in... 
        public static IEnumerable<T> Cast<T>(this IEnumerable source, Func<T> template)
        {
            return Enumerable.Cast<T>(source);
        }


        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> data, Func<T, bool> predicate)
        {
            foreach (T value in data)
            {
                if (predicate(value))
                    yield return value;
            }
        }

    }
}
