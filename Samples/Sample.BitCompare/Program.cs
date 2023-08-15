using System;
using System.IO;

namespace Sample.BitCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Compara 2 arquivos em bytes");

            Console.WriteLine("Informe o caminho completo do primeiro arquivo");
            var file1 = Console.ReadLine();

            Console.WriteLine("Informe o caminho completo do segundo arquivo");
            var file2 = Console.ReadLine();

            try
            {
                byte[] b1 = File.ReadAllBytes(file1);
                byte[] b2 = File.ReadAllBytes(file2);

                if (BitConverter.ToString(b1).Equals(BitConverter.ToString(b2)))
                {
                    Console.WriteLine("Arquivos idênticos!");
                }
                else
                {
                    Console.WriteLine("Estes arquivos são diferentes!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
