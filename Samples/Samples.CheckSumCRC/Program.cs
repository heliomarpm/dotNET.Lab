using System;
using System.IO;

namespace Samples.CheckSumCRC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Checkum CRC Stream");

            //Abre um fluxo de stream e o encapsula em um CrcStream
            try
            {
                Console.WriteLine("Informe o caminho completo do primeiro arquivo");
                string pathFile = Console.ReadLine();

                FileStream file = new(pathFile, FileMode.Open);
                CRCStream stream = new(file);

                //Usa o arquivo - neste caso le o arquivo como uma string
                StreamReader reader = new(stream);
                string texto = reader.ReadToEnd();

                //Imprime o checksum calculado
                Console.WriteLine(stream.ReadCrc.ToString("X8"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar o arquivo :  " + ex.Message);
            }
            Console.Read();

        }
    }
}
