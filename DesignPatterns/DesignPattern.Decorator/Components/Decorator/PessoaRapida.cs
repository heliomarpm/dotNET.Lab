using System;
using System.Text;

namespace Decorator
{
    //Decorator    
    class PessoaRapida : IPessoa
    {
        //Component : IComponent        
        IPessoa p;

        public PessoaRapida(IPessoa p)
        {
            this.p = p;
        }

        //Operation        
        public String Andar()
        {
            return new StringBuilder(p.Andar())
                        .Append(" ")
                        .Append("rápido")
                        .ToString();
        }

        //AddedBehavior        
        public String Correr()
        {
            return "corri";
        }
    }
}
