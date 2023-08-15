using System;

namespace Decorator
{
    //Component    
    sealed class Pessoa : IPessoa
    {
        //Operation        
        public String Andar()
        {
            return "andei";
        }
    }
}
