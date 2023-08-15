using DesignPattern.ChainOfResponsability;
using System;

namespace Pattern.ChainOfResponsability
{
    class Diretor : Aprovar
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (sucessor != null)
            {
                sucessor.ProcessRequest(purchase);
            }
        }
    }
}
