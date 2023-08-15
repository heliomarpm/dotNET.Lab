using System;
using System.Linq;

namespace Sample.Aleatorios
{
    public static class DesafiosCodeWars
    {
        public static void IsIsogram()
        {
            Console.WriteLine($"Dermatoglyphics {IsIsogram("Dermatoglyphics")}");
            Console.WriteLine($"isogram {IsIsogram("isogram")}");
            Console.WriteLine($"moose {IsIsogram("moose")}");
            Console.WriteLine($"isIsogram {IsIsogram("isIsogram")}");
            Console.WriteLine($"Aba {IsIsogram("Aba")}");
            Console.WriteLine($"moOse {IsIsogram("moOse")}");
            Console.WriteLine($"thumbscrewjapingly {IsIsogram("thumbscrewjapingly")}");
            Console.WriteLine($"'' {IsIsogram("")}");
        }

        public static bool IsIsograma(string str) => str.ToLower().Distinct().Count() == str.Length;

        //public bool IsIsogram(string value)
        //{
        //    value = value.Replace(" ", "").Replace("-", "");

        //    string result = value;
        //    return result.ToLower().Distinct().Count() == value.Length;
        //}

        public static bool IsIsogram(string str)
        {
            var aChr = str.ToLower().ToCharArray();
            Array.Sort(aChr);

            for (int i = 1; i < str.Length; i++)
            {
                if (aChr[i - 1] == aChr[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static void Multiple()
        {
            Console.WriteLine(SumMultiples3or5(10));

            var soma = Enumerable.Range(0, 10).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
            Console.WriteLine(soma);
        }

        static int SumMultiples3or5(int value)
        {
            int soma = 0;
            for (int i = 0; i < value; i++)
            {
                if (i.IsMultiple(3) || i.IsMultiple(5))
                {
                    soma += i;
                }
            }

            return soma;
        }

        static bool IsMultiple(this int value, int mult)
        {
            return value % mult == 0;
        }


        public static string UCamelCase(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            var values = value.Split('-', '_', ' ');
            string result = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                result += values[i].Substring(0, 1).ToUpper() + values[i].Substring(1);
            }

            return result;
        }

        public static string ToUCamelCase(string value)
        {
            var arrValue = value.Split('-', '_', ' ');
            return string.Concat(arrValue.Select((s, i) => i > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s));

            //return System.Text.RegularExpressions.Regex.Replace(value, @"[_-](\w)", m => m.Groups[1].Value.ToUpper());
        }
    }
}
