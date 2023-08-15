using System;

namespace Sample.SealedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass ob1 = new DerivedClass();

            ob1.Display();

            Console.ReadLine();


            //BaseClass2 obj2 = new BaseClass2();                        
            //obj2.Display();
            //Console.ReadLine(); 
        }

        public class BaseClass
        {
            public virtual void Display()
            {
                Console.WriteLine("Virtual method");
            }
        }

        public class DerivedClass : BaseClass
        {
            // Now the display method have been sealed and can;t be overridden 
            public override sealed void Display()
            {
                Console.WriteLine("Sealed method");
            }
        }

        //public class ThirdClass : DerivedClass 
        //{ 
        //    public override void Display() 
        //    { 
        //        Console.WriteLine("Here we try again to override display method which is not possible and will give error"); 
        //    } 
        //} 
    }
}
