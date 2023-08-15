using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Sample.Aleatorios
{
    public enum Language
    {
        CSharp = 0,
        Java = 1,
        VB = 2
    }

    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; protected set; }
    }

    public class Jogador : Pessoa
    {
        public Jogador(string nome)
        {
            this.Nome = nome;
        }
    }


    public static class Extensions
    {
        public static T GetValue<T>(this List<T> vetor, int index)
        {
            T value = default(T);

            if (index < vetor.Count)
            {
                value = vetor[index];
            }

            return value;
        }
    }

    class ErrRaise : Exception
    {
        private string msg;

        public ErrRaise(int num, string desc, string source)
        {
            this.Number = num;
            this.msg = desc;
            base.Source = source;
        }
        public int Number { get; set; }

        public override string Message
        {
            get
            {
                return this.msg;
            }
        }
    }

    class Program
    {
        enum enumFuncaoLMax
        {
            None = 0,
            Reserva = 5,
            LiberaResera = 6,
            ExcluiReserva = 15
        }


        static void testeCombustivel()
        {
            int c;
            do
            {

                c = Convert.ToInt32(Console.ReadLine());

                switch (c)
                {
                    case 1:
                        Console.WriteLine("Álcool");
                        break;
                    case 2:
                        Console.WriteLine("Gasolina");
                        break;
                    case 3:
                        Console.WriteLine("Diesel");
                        break;
                    case 4:
                        Console.WriteLine("MUITO OBRIGADO");
                        break;
                    default:
                        continue;
                }
            }

            while (c < 1 || c > 4);

        }

        static double AreaCirculo(double raio)
        {
            //double raio = Convert.ToDouble(Console.ReadLine());
            double n = 3.14159;
            double area = n * Math.Pow(raio, 2);
            Console.WriteLine($"A={area:n4}");
            Console.WriteLine("A={0:0.0000}", area);

            return area;
        }

        static void MediaNotas()
        {
            double A = Convert.ToDouble(Console.ReadLine()) * 3.5;
            double B = Convert.ToDouble(Console.ReadLine()) * 7.5;

            double MEDIA = (A + B) / 11;
            Console.WriteLine("MEDIA = {0:0.00000}", MEDIA);
        }
        static void MediaNotas2()
        {
            double A = Convert.ToDouble(Console.ReadLine()) * 2;
            double B = Convert.ToDouble(Console.ReadLine()) * 3;
            double C = Convert.ToDouble(Console.ReadLine()) * 5;

            double MEDIA = (A + B + C) / 10;
            Console.WriteLine("MEDIA = {0:0.0}", MEDIA);
        }

        static void Main(string[] args)
        {
            Abstracao.Run();

            MediaNotas2();

            Console.ReadKey();
            return;
            //Console.WriteLine($"SOMA = {SOMA}");

            Console.WriteLine($"A={AreaCirculo(2)}");
            Console.WriteLine($"A={AreaCirculo(100.64)}");
            Console.WriteLine("A={0:0.0000}", AreaCirculo(150.00));

            testeCombustivel();

            Console.Read();
            return;


            DesafiosCodeWars.Multiple();
            Console.WriteLine(DesafiosCodeWars.UCamelCase("the-stealth-warrior"));
            Console.WriteLine(DesafiosCodeWars.UCamelCase("The_Stealth_Warrior"));
            Console.WriteLine(DesafiosCodeWars.ToUCamelCase("The_Stealth Warrior"));
            Console.WriteLine(DesafiosCodeWars.ToUCamelCase(""));
            Console.ReadKey();

            RegexSamples.Run();

            Console.WriteLine("Div. 10 / 2: {0}", 10 / 2);
            Console.WriteLine("Shift 10 * 2 >> 2: {0}", 10 * 2 >> 2); //mais rapido que divisão

            tabelaArquivosEncontrados();
            return;

            Language[] languageEnumList = (Language[])Enum.GetValues(typeof(Language));

            foreach (var item in languageEnumList)
            {
                Console.WriteLine(item.ToString());
            }

            string[] namesEnumList = Enum.GetNames(typeof(Language));

            for (int i = 0; i < namesEnumList.Length; i++)
            {
                Console.WriteLine(namesEnumList[i]);
            }
            Console.Read();
            var path = @"D:\Users\hemsantos\Desktop\AK9\AK9_HL_RATING.txt";
            //var folder = Path.GetDirectoryName(@"D:\Users\aandrejauskas\Desktop\Rating\AK9_HL_RATING.txt");
            var folder = Directory.GetParent(path);

            Console.WriteLine(folder.FullName);
            Console.Write("------------------------------------------\n");
            if (folder.Exists)
            {

                string fileName = Path.GetFileNameWithoutExtension(path);

                /*
                //Criar arquivos para teste
                string newFile;
                for (int i = 0; i <= 150; i++)
                {
                newFile = path + @"\" + DateTime.Today.AddDays(-i).ToString("ddMMyyyy_") + fileName + DateTime.Today.AddDays(-i).ToString("_yyyyMMdd") + ".csv_transmitido";
                if (!File.Exists(newFile))
                File.Create( newFile );
                }

                return;


                YieldReturnSample.Run();
                return;
                DesafioPrimeiroAbril.Run();
                return;

                var jg = new Jogador("Heliomar")
                {
                Id = 0
                };
                */
                DateTime manterArquivo = DateTime.Now.AddDays(-45); //Manter os ultimos 45 dias
                var files = Directory.GetFiles(folder.FullName, string.Concat("*", fileName, "*.csv_transmitido"), SearchOption.TopDirectoryOnly);//.OrderBy(f => new FileInfo(f).CreationTime);
                string dateFileName;

                foreach (var file in files)
                {
                    Console.Write(Path.GetFileName(file));
                    //Pega a data contida no nome do arquivo
                    dateFileName = Path.GetFileNameWithoutExtension(file).Substring(0, 8); //.Replace(fileName + "_", "");

                    //Mantem apenas os arquivos dos ultimos 45 dias
                    if (manterArquivo > DateTime.ParseExact(dateFileName, "ddMMyyyy", CultureInfo.CurrentCulture))
                    {
                        File.Delete(file);
                        Console.Write(" -> excluido");
                    }
                    //else { break; }
                    Console.WriteLine();

                    /*
                    string fileName = Path.GetFileName(file);
                    var fileinfo = new FileInfo(file);
                    long fileSize = fileinfo.Length;
                    Console.WriteLine("{0}/{1}", fileName, fileSize);
                    */
                }
            }

            Console.ReadKey();
            return;


            DateTime d1 = new DateTime(2016, 1, 20);
            DateTime d2 = new DateTime(2016, 1, 22);
            DateTime d3 = DateTime.Now.AddDays(5);

            //Console.WriteLine(DateTime.Compare(d1,d2));
            //Console.WriteLine(DateTime.Compare(d3, d2));
            //Console.WriteLine(DateTime.Compare(d2, DateTime.Now));

            //Console.WriteLine((int)(d1 - d2).TotalDays);
            //Console.WriteLine((int)(d2 - d1).TotalDays);
            //Console.WriteLine((int)(d3 - d2).TotalDays);

            //Console.WriteLine((int)(d2 - DateTime.Now).TotalDays);
            //Console.WriteLine((int)(DateTime.Now-d1).TotalDays);
            //Console.WriteLine((DateTime.Now - d1).TotalDays);

            d1 = new DateTime(2016, 01, 29, 0, 0, 0);
            d2 = new DateTime(2016, 01, 29, 23, 59, 59);

            Console.WriteLine((d2 - d1).TotalDays);
            Console.WriteLine((d1 - d2).TotalDays);
            Console.WriteLine((int)(d1 - d2).TotalDays);

            Console.WriteLine((d1.AddDays(-2) - DateTime.Now).TotalDays);
            Console.WriteLine((int)(d1.AddDays(-3) - DateTime.Now).TotalDays);

            Console.WriteLine((int)(d1.AddDays(3) - DateTime.Now).TotalDays);
            Console.WriteLine((int)(DateTime.Now - d1.AddDays(3)).TotalDays);
            Console.WriteLine((int)(DateTime.Now - d1.AddDays(-3)).TotalDays);

            Console.Read();
            return;

            try
            {
                int valor = 0;
                int x = 2 / valor;
            }
            catch (Exception ex)
            {
                throw new ErrRaise(1001, ex.Message, ex.Source);
            }

            Console.WriteLine("<<<<<<< FINALIZADO! >>>>>");
            Console.ReadKey();
            return;
            AnaliseCombinatoria.RunInterator();
            return;
            Assembly SampleAssembly;

            // Instantiate a target object.
            Int32 Integer1 = new Int32();
            Type Type1;
            // Set the Type instance to the target class type.
            Type1 = Integer1.GetType();
            // Instantiate an Assembly class to the assembly housing the Integer type.  
            SampleAssembly = Assembly.GetAssembly(Integer1.GetType());

            Console.WriteLine(SampleAssembly.FullName);

            // Display the name of the assembly currently executing
            Console.WriteLine("GetExecutingAssembly=" + Assembly.GetExecutingAssembly().FullName);

            Console.ReadKey();

            string[] elements = { "cat", "dog", "fish" };
            Console.WriteLine(elements[0]);

            // ... Join strings into a single string.
            string joined = string.Join("|", elements);
            Console.WriteLine(joined);

            // ... Separate joined strings with Split.
            string[] separated = joined.Split('|');
            Console.WriteLine(separated[0]);

            //decimal[] valor2 = { 0.1m, 1.2m, 2.3m };// new decimal[3];

            //for (int i = 0; i < valor2.Length; i++)
            //{
            //    Console.WriteLine(valor2[i]);    
            //}

            //Console.WriteLine(valor2.ToList().GetValue(4));

            //return;

            //LoadEndpoints.Run2();
            //return;

            //Console.WriteLine("{0} - {1}", jg.Id, jg.Nome);
            Console.ReadLine();

            TurnOnClearType();
            return;

            for (char c = 'A'; c < 'Z'; c++)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();
            Console.WriteLine("1".PadLeft(5, '0'));

            DateTimeFormatInfo dti = new CultureInfo("pt-BR", false).DateTimeFormat;
            //DateTimeFormatInfo ukDtfi = new CultureInfo("en-GB", false).DateTimeFormat;
            //string result = Convert.ToDateTime("12/01/2011", usDtfi).ToString(ukDtfi.ShortDatePattern)
            Console.WriteLine(Convert.ToDateTime("23/11/2011", dti).ToString("yyyy-MM-dd"));
            Console.WriteLine(Convert.ToDateTime("12/23/2011", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"));

            decimal dec1 = 0;
            dec1 = Convert.ToDecimal("12,254", new CultureInfo("en-US"));
            Console.WriteLine(dec1);

            dec1 = Convert.ToDecimal("12.254", new CultureInfo("en-US"));
            Console.WriteLine(dec1);

            dec1 = Convert.ToDecimal("13,254", CultureInfo.InvariantCulture);
            Console.WriteLine(dec1);

            dec1 = Convert.ToDecimal("13.254", CultureInfo.InvariantCulture);
            Console.WriteLine(dec1);

            dec1 = Convert.ToDecimal("14,254");
            Console.WriteLine(dec1);

            dec1 = Convert.ToDecimal("14.254");
            Console.WriteLine(dec1);

            Console.ReadKey();
            return;

            //ServiceHelpTest.Run();
            //return;

            //Console.WriteLine(string.Format("n{0}", 123));
            //Console.WriteLine(string.Format("{0:p}", 123000.6));
            //Console.WriteLine(string.Format("{0:f}", 123000.6));
            //Console.WriteLine(string.Format("{0:n}", 123000.6));


            //if (System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.Equals(","))
            //    Console.WriteLine(string.Format("{0:n}", double.Parse("1123990,653")));
            //else
            //    Console.WriteLine(string.Format("{0:n}", decimal.Parse("2123000,653")));


            // The input value.
            string value = "Reserva";

            // An unitialized variable.
            enumFuncaoLMax fncLMax;

            // Call Enum.TryParse method.
            if (Enum.TryParse(value, out fncLMax))
            {
                // We now have an enum type.
                Console.WriteLine(fncLMax == enumFuncaoLMax.Reserva);
            }

            value = "6";
            // Call Enum.TryParse method.
            if (Enum.TryParse(value, out fncLMax))
            {
                // We now have an enum type.
                Console.WriteLine(fncLMax == enumFuncaoLMax.LiberaResera);
            }

            if (fncLMax.ToString().Equals(value))
                fncLMax = enumFuncaoLMax.None;

            Console.WriteLine(fncLMax.ToString());

            Console.ReadKey();

            Console.WriteLine(decimal.Parse(double.Parse("2366.7").ToString()).ToString("n2"));
            Console.WriteLine(decimal.Parse("1000").ToString("n0"));

            double dd = 4522.63;
            Console.WriteLine(dd.ToString());
            Console.WriteLine(decimal.Parse(dd.ToString()).ToString("n2"));
            Console.WriteLine(string.Format("{0:#0.#######}", dd.ToString()));
            Console.WriteLine(decimal.Parse(string.Format("{0:#0.#######}", dd.ToString())).ToString("n2"));
            Console.WriteLine(double.Parse(string.Format("{0:#0.#######}", dd.ToString())));

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine(string.Format("{0:#0.#######}", decimal.Parse("122,233,000.57")));

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat.CurrencyGroupSeparator = ".";

            Console.WriteLine(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine(string.Format("{0:#0.#######}", decimal.Parse("98.233.000,57")));

            LogEventViewer.Log("Executado exemplos aleatorios");

            Console.ReadKey();
        }


        static void TurnOnClearType()
        {
            //The command you want to use is the reg command.
            //The keys of interest is HKEY_CURRENT_USER\Control Panel\Desktop
            //There's a string value named FontSmoothing. Value of 0 = disabled, 2 = enabled.
            //Then there's a dword value named FontSmoothingType. Value of 0 = disabled, 1 = normal, 2 = cleartype.

            //To enable cleartype:
            //REG ADD "HKCU\Control Panel\Desktop" /v FontSmoothing /d 2
            //REG ADD "HKCU\Control Panel\Desktop" /v FontSmoothingType /t REG_DWORD /d 00000002

            //To revert to normal font smoothing:
            //REG ADD "HKCU\Control Panel\Desktop" /v FontSmoothing /d 2
            //REG ADD "HKCU\Control Panel\Desktop" /v FontSmoothingType /t REG_DWORD /d 00000001

            //To turn font smoothing off:
            //REG ADD "HKCU\Control Panel\Desktop" /v FontSmoothing /d 0
            //REG ADD "HKCU\Control Panel\Desktop" /v FontSmoothingType /t REG_DWORD /d 00000000

            using (var regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
            {
                foreach (var item in regKey.GetValueNames())
                {
                    Console.WriteLine("{0}:\t{1}\t-{2}", item, regKey.GetValue(item).ToString(), regKey.GetValueKind(item).ToString());
                }

                //off
                regKey.SetValue("FontSmoothing", "0", RegistryValueKind.String);
                regKey.SetValue("FontSmoothingType", "00000000", RegistryValueKind.DWord);

                //on
                regKey.SetValue("FontSmoothing", "2", RegistryValueKind.String);
                regKey.SetValue("FontSmoothingType", "00000002", RegistryValueKind.DWord);
            }

            Console.Read();
        }


        static void tabelaArquivosEncontrados()
        {
            string dataBase = DateTime.Now.ToString("dd/MM/yyyy");

            var registro = new Dictionary<string, Dictionary<string, int>>()
            {
                {"Coluna A", new Dictionary<string, int>(){{ "Arquivo 1", 0 },{ "Arquivo 2", 0 },{ "Arquivo 3", 0 } } },
                {"Coluna B", new Dictionary<string, int>(){{ "Arquivo 1", 1 },{ "Arquivo 2", 0 },{ "Arquivo 3", 0 } } },
                {"Coluna C", new Dictionary<string, int>(){{ "Arquivo 1", 0 },{ "Arquivo 2", 1 },{ "Arquivo 3", 1 } } },
                {"Coluna D", new Dictionary<string, int>(){{ "Arquivo 1", 1 },{ "Arquivo 2", 1 },{ "Arquivo 3", 1 } } }
            };

            var theader = new StringBuilder();
            var tdRows = new List<string>();
            int indexRow;

            theader.Append("<theader><tr>")
                   .Append("<th>" + dataBase + "</th>");

            foreach (var item in registro)
            {
                theader.Append("<th>" + item.Key + "</th>");

                indexRow = 0;
                foreach (var row in item.Value)
                {
                    if (tdRows.Count < item.Value.Count)
                        tdRows.Add("<tr><td>" + row.Key + "</td>");

                    tdRows[indexRow++] += "<td>" + row.Value + "</td>";
                }
            }
            for (int i = 0; i < tdRows.Count; i++)
            {
                tdRows[i] += "</tr>";
            }
            theader.Append("</tr></theader>");

            var htmlTable = new StringBuilder();
            htmlTable.AppendLine("<table>")
                     .AppendLine(theader.ToString())
                     .AppendLine("<tbody>")
                     .AppendLine(string.Join(Environment.NewLine, tdRows.ToArray()))
                     .AppendLine("</tbody>")
                     .AppendLine("</table>");

            Console.WriteLine(htmlTable.ToString());
            Console.Read();

        }
    }
}
