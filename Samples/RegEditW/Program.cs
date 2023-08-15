using Microsoft.Win32;
using System;

namespace RegEditW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RegEdit for Windows");

            Console.WriteLine("Sofware Count: {0}", Registry.LocalMachine.OpenSubKey("Software").SubKeyCount);

            foreach (var item in Registry.LocalMachine.OpenSubKey("Software").GetSubKeyNames())
            {
                Console.WriteLine("SubKeyName: {0}", item);
            }

            Console.WriteLine(@"Digite um valor para criar uma nova chave/valor em CurrenteUser\Software\Heliomar\NovoValor");
            var newRValue = Console.ReadLine();

            using (var reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Heliomar"))
            {
                reg.SetValue("NovoValor", newRValue);
            }
            Console.Read();
            Console.WriteLine("Valor gravado: {0}", Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Heliomar").GetValue("NovoValor"));
            Registry.CurrentUser.DeleteSubKeyTree(@"SOFTWARE\Heliomar");
            Console.WriteLine("Chave Excluída");
            Console.Read();
        }
    }
}
