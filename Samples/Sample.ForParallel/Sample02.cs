﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.ForParallel
{
    /// <summary>
    /// http://www.dotnetcurry.com/ShowArticle.aspx?ID=608
    /// </summary>
    public class Sample02
    {
        public static void Run()
        {
            Console.WriteLine("Sample02: Using C# For Loop \n");

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("i = {0}, thread = {1}",
                    i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }

            Console.WriteLine("\nUsing Parallel.For \n");

            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
