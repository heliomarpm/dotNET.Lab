using System;
using System.Collections.Generic;

namespace Sample.RemoveFromList
{
    class Program
    {
        static void Main(string[] args)
        {
            var cust1 = new Customer(10, "Heliomar");

            Console.WriteLine(cust1.GetHashCode());
            Console.ReadLine();

            List<Customer> collCustList = new List<Customer>();

            collCustList.Add(new Customer(0, "AA", "Pow"));
            collCustList.Add(new Customer(1, "BB", "Good"));
            collCustList.Add(new Customer(2, "CC", "Gold"));
            collCustList.Add(new Customer(3, "DD", "Oyo"));
            collCustList.Add(new Customer(4, "EE", "Dead"));
            collCustList.Add(new Customer(5, "FF", "Poo"));
            collCustList.Add(new Customer(6, "EE", "Only"));

            Console.WriteLine("<<<< TODOS OS ITENS >>>>");

            foreach (Customer cust in collCustList)
                Console.Out.WriteLine(cust);


            Console.WriteLine("\n <<<< RemoveAt(6) >>>>");

            collCustList.RemoveAt(6);
            foreach (Customer cust in collCustList)
                Console.Out.WriteLine(cust);

            Console.WriteLine("\n <<<< RemoveRange(3,2) >>>>");

            collCustList.RemoveRange(3, 2);
            foreach (Customer cust in collCustList)
                Console.Out.WriteLine(cust);

            Console.WriteLine("\n <<<< RemoveAll(delegate Name CC) >>>>");
            int numRemoved = collCustList.RemoveAll(delegate (Customer p)
            {
                return p.Name.Equals("CC");
            });

            Console.WriteLine(string.Format("Removed: {0}", numRemoved));

            Console.WriteLine("\n <<<< Sobrou >>>>");
            foreach (Customer cust in collCustList)
                Console.Out.WriteLine(cust);

            collCustList.Clear();

            Console.ReadKey();
        }
    }
}
