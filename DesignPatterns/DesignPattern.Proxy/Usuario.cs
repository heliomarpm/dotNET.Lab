using System;
using System.Threading;

namespace Proxy
{
    //Subject    
    public class Usuario
    {
        public Usuario()
        {
            Console.WriteLine("criei");
            Thread.Sleep(2000);
        }

        //Request()        
        public String Consultar()
        {
            return String.Format("consultei");
        }
    }

}
