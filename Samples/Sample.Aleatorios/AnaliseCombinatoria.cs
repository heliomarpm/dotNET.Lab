using System;
using System.Collections.Generic;

namespace Sample.Aleatorios
{
    public class PermuteUtils
    {
        // Returns an enumeration of enumerators, one for each permutation of the input.
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
                        yield return Concat<T>(new T[] { startingElement }, permutationOfRemainder);
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

        // Enumerates over all items in the input, skipping over the item with the specified offset.
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

    //Algoritimo Binomial
    public class AnaliseCombinatoria
    {
        public static void RunInterator()
        {
            int[] intInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ShowPermutations<int>(intInput, 2, 2);

            string[] stringInput = { "Hello", "World", "Foo" };
            ShowPermutations<string>(stringInput, 3, 3);

            string[] stringInput2 = { "A", "B", "C" };
            ShowPermutations<string>(stringInput2, 1, 3);

            int[] intInput2 = { 1, 2, 3, 4, 5, 6 };
            ShowPermutations<int>(intInput2, 6, 6);

            Console.ReadKey();
        }

        // Print out the permutations of the input 
        static void ShowPermutations<T>(IEnumerable<T> input, int countMin, int countMax)
        {
            for (int count = countMin; count <= countMax; count++)
            {
                foreach (IEnumerable<T> permutation in PermuteUtils.Permute<T>(input, count))
                {
                    foreach (T i in permutation)
                    {
                        Console.Write(" " + i);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}

