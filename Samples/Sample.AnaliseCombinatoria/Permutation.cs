using System;
using System.Collections.Generic;

namespace Sample.AnaliseCombinatoria
{
    /// <summary>
    /// O conceito de permutação expressa a idéia de que objetos distintos podem 
    /// ser arranjados em inúmeras ordens distintas.
    /// Assim seja um conjunto A com n elementos, chamamos de permutação a todo arranjo com n elementos retirados de A.
    /// A cada um dos agrupamentos que podemos formar com certo número de elementos distintos, tal que a 
    /// diferença entre um agrupamento e outro se dê apenas pela mudança de posição 
    /// entre seus elementos, damos o nome de permutação simples.
    /// </summary>
    public class Permutation
    {

        public static void Run()
        {
            Console.WriteLine("-------- EXEMPLO PERMUTAÇÃO -----------\n\n");
            int[] intInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ShowPermutations<int>(intInput, 2, 3);

            string[] stringInput = { "Hello", "World", "Foo" };
            ShowPermutations<string>(stringInput, 1, 3);

            string[] stringInputA = { "A", "B", "C" };
            ShowPermutations<string>(stringInputA, 1, stringInputA.Length);

            Console.WriteLine(TestPermute2("ABC", "CA"));
            //var res = TestPermute("ABC", "BC");
            //for (int i = 0; i < res.Count; i++)
            //{
            //    Console.WriteLine(res[i]);
            //}
            Console.ReadKey();

            Console.WriteLine("-------- EXEMPLO PERMUTAÇÃO -----------\n\n");
            int[] intInput2 = { 1, 2, 3, 4, 5, 6 };
            ShowPermutations<int>(intInput2, 6, 6);
            Console.ReadKey();
        }

        private static bool TestPermute(string validValues, string validValuesCompare)
        {
            List<string> result = new List<string>();
            string combination = "";

            string[] input = new string[validValues.Length];

            for (int i = 0; i < validValues.Length; i++)
            {
                input[i] = validValues[i].ToString();
            }

            for (int size = 1; size <= validValues.Length; size++)
            {
                foreach (IEnumerable<string> permutation in Permutation.Permute<string>(input, size))
                {
                    foreach (string p in permutation)
                    {
                        combination += p;
                    }
                    result.Add(combination);
                    combination = string.Empty;
                }
            }

            return result.Contains(validValuesCompare);
        }

        private static bool TestPermute2(string inputValues, string compareValues)
        {
            bool sucess = false;
            string[] input = new string[inputValues.Length];
            string combination = "";

            for (int i = 0; i < inputValues.Length; i++)
            {
                input[i] = inputValues[i].ToString();
            }

            for (int size = 1; size <= inputValues.Length; size++)
            {
                foreach (IEnumerable<string> permutation in Permutation.Permute<string>(input, size))
                {
                    foreach (string p in permutation)
                    {
                        combination += p;
                    }
                    sucess = (combination.Equals(compareValues));
                    combination = string.Empty;

                    if (sucess) break;
                }
                if (sucess) break;
            }

            return sucess;
        }

        // Print out the permutations of the input 
        public static void ShowPermutations<T>(IEnumerable<T> input, int minSize, int maxSize)
        {
            for (int size = minSize; size <= maxSize; size++)
            {
                foreach (IEnumerable<T> permutation in Permute<T>(input, size))
                {
                    foreach (T i in permutation)
                    {
                        Console.Write(" " + i);
                    }
                    Console.WriteLine();
                }
            }

        }

        public static bool CompareValues(string inputValues, string compareValues)
        {
            bool sucess = inputValues.Equals(compareValues);

            if (!sucess)
            {
                string[] input = new string[inputValues.Length];
                string combination = "";

                for (int i = 0; i < inputValues.Length; i++)
                {
                    input[i] = inputValues[i].ToString();
                }

                for (int size = 1; size <= inputValues.Length; size++)
                {
                    foreach (IEnumerable<string> permutation in Permutation.Permute<string>(input, size))
                    {
                        foreach (string p in permutation)
                        {
                            combination += p;
                        }
                        sucess = (combination.Equals(compareValues));
                        combination = string.Empty;

                        if (sucess) break;
                    }
                    if (sucess) break;
                }
            }
            return sucess;
        }


        // Returns an enumeration of enumerators, one for each permutation
        // of the input.
        public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> list, int count)
        {
            if (count == 0)
            {
                yield return new T[0];
            }
            else
            {
                int startingElementIndex = 0;
                foreach (T startingElement in list)
                {
                    IEnumerable<T> remainingItems = AllExcept(list, startingElementIndex);

                    foreach (IEnumerable<T> permutationOfRemainder in Permute(remainingItems, count - 1))
                    {
                        yield return Concat<T>(
                            new T[] { startingElement },
                            permutationOfRemainder);
                    }
                    startingElementIndex += 1;
                }
            }
        }

        // Enumerates over contents of both lists.
        private static IEnumerable<T> Concat<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            foreach (T item in a) { yield return item; }
            foreach (T item in b) { yield return item; }
        }

        // Enumerates over all items in the input, skipping over the item
        // with the specified offset.
        private static IEnumerable<T> AllExcept<T>(IEnumerable<T> input, int indexToSkip)
        {
            int index = 0;
            foreach (T item in input)
            {
                if (index != indexToSkip) yield return item;
                index += 1;
            }
        }
    }


}
