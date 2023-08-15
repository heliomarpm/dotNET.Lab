using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Sample.ReflectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var propA = typeof(Foo).GetProperty("PropertyA");
            var attribute = propA.GetCustomAttributes(typeof(DescriptionAttribute), true).OfType<DescriptionAttribute>().First();

            Console.WriteLine(attribute.Description);


            MyClass mc = new MyClass();

            //mc.IdTeste = 1;
            mc.MinhaPropriedade = "valor da propriedade";
            mc.MeuAtributo = "valor do atributo";

            Console.WriteLine("\n >> Fields");
            foreach (FieldInfo item in mc.GetType().GetFields())
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.GetValue(mc));
                item.SetValue(mc, "Novo valor para o atributo");
                Console.WriteLine(item.GetValue(mc));
            }

            Console.WriteLine("\n >> Propriedades");
            foreach (PropertyInfo item in mc.GetType().GetProperties())
            {
                Console.WriteLine(String.Concat(item.Name, " ", item.PropertyType.ToString()));
                Console.WriteLine(item.GetValue(mc, null));
                item.SetValue(mc, "Novo valor para a propriedade", null);
                Console.WriteLine(item.GetValue(mc, null));

            }


            Console.WriteLine();

            Type t = typeof(MyClass2);
            Console.WriteLine("Type of class: " + t);
            Console.WriteLine("Namespace: " + t.Namespace);
            ConstructorInfo[] ci = t.GetConstructors();
            PropertyInfo[] pi = t.GetProperties();
            Console.WriteLine("Properties are:");

            foreach (PropertyInfo i in pi)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("\n\nexemploGetValueProp");
            exemploGetValueProp();

            //Console.WriteLine("\n\nPrintAssembly");
            //PrintAssembly();

            Console.ReadKey();
        }
        static void exemploGetValueProp()
        {
            string test = "abcdefghijklmnopqrstuvwxyz";

            // To retrieve the value of the indexed Chars property using
            // reflection, first get a PropertyInfo for Chars.
            PropertyInfo pinfo = typeof(string).GetProperty("Chars");

            // To retrieve an instance property, the GetValue method
            // requires the object whose property is being accessed and an
            // array of objects representing the index values.

            // Show the seventh letter (h)
            object[] indexArgs = { 7 };
            object value = pinfo.GetValue(test, indexArgs);

            Console.WriteLine(value);

            // Show the complete string.
            for (int x = 0; x < test.Length; x++)
            {
                Console.Write(pinfo.GetValue(test, new Object[] { x }));
            }

        }

        public static void PrintAssembly()
        {
            // This variable holds the amount of indenting that 
            // should be used when displaying each line of information.
            Int32 indent = 0;
            // Display information about the EXE assembly.
            Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            Display(indent, "Assembly identity={0}", a.FullName);
            Display(indent + 1, "Codebase={0}", a.CodeBase);

            // Display the set of assemblies our assemblies reference.

            Display(indent, "Referenced assemblies:");
            foreach (AssemblyName an in a.GetReferencedAssemblies())
            {
                Display(indent + 1, "Name={0}, Version={1}, Culture={2}, PublicKey token={3}", an.Name, an.Version, an.CultureInfo.Name, (BitConverter.ToString(an.GetPublicKeyToken())));
            }
            Display(indent, "");

            // Display information about each assembly loading into this AppDomain.
            foreach (Assembly b in AppDomain.CurrentDomain.GetAssemblies())
            {
                Display(indent, "Assembly: {0}", b);

                // Display information about each module of this assembly.
                foreach (Module m in b.GetModules(true))
                {
                    Display(indent + 1, "Module: {0}", m.Name);
                }

                // Display information about each type exported from this assembly.

                indent += 1;
                foreach (Type t in b.GetExportedTypes())
                {
                    Display(0, "");
                    Display(indent, "Type: {0}", t);

                    // For each type, show its members & their custom attributes.

                    indent += 1;
                    foreach (MemberInfo mi in t.GetMembers())
                    {
                        Display(indent, "Member: {0}", mi.Name);
                        DisplayAttributes(indent, mi);

                        // If the member is a method, display information about its parameters.

                        if (mi.MemberType == MemberTypes.Method)
                        {
                            foreach (ParameterInfo pi in ((MethodInfo)mi).GetParameters())
                            {
                                Display(indent + 1, "Parameter: Type={0}, Name={1}", pi.ParameterType, pi.Name);
                            }
                        }

                        // If the member is a property, display information about the property's accessor methods.
                        if (mi.MemberType == MemberTypes.Property)
                        {
                            foreach (MethodInfo am in ((PropertyInfo)mi).GetAccessors())
                            {
                                Display(indent + 1, "Accessor method: {0}", am);
                            }
                        }
                    }
                    indent -= 1;
                }
                indent -= 1;
            }
        }

        // Displays the custom attributes applied to the specified member.
        public static void DisplayAttributes(Int32 indent, MemberInfo mi)
        {
            // Get the set of custom attributes; if none exist, just return.
            object[] attrs = mi.GetCustomAttributes(false);

            if (attrs.Length == 0)
            {
                return;
            }

            // Display the custom attributes applied to this member.
            Display(indent + 1, "Attributes:");
            foreach (object o in attrs)
            {
                Display(indent + 2, "{0}", o.ToString());
            }
        }

        // Display a formatted string indented by the specified amount.
        public static void Display(Int32 indent, string format, params object[] param)
        {
            Console.Write(new string(' ', indent * 2));
            Console.WriteLine(format, param);
        }

    }

    class MyClass
    {
        private int IdTeste { get; set; }
        public string MinhaPropriedade { get; set; }

        public string MeuAtributo;

        public void MeuMetodo()
        { }

        public string MinhaFuncao()
        {
            return "";
        }
    }

    public class MyClass2
    {
        public int pubInteger;

        public MyClass2()
        { }

        public MyClass2(int IntegerValueIn)
        {
            pubInteger = IntegerValueIn;
        }

        public int Add10(int IntegerValueIn)
        {
            Console.WriteLine(IntegerValueIn);
            return IntegerValueIn + 10;
        }

        public int TestProperty { get; set; }

    }

    public class Foo
    {
        public int FieldA;

        [Description("Descricao da propriedade PropertyA")]
        public int PropertyA { get; set; }

        public string Bar(int parameter)
        {
            return "abc";
        }
    }
}
