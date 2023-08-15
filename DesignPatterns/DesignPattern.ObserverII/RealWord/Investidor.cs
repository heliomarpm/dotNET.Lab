using System;

namespace DesignPattern.ObserverII.RealWord
{
    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    class Investidor : IInvestidor
    {
        private string _name;
        private AStock _stock;

        // Constructor
        public Investidor(string name)
        {
            this._name = name;
        }

        public void Update(AStock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s change to {2:C}", _name, stock.Symbol, stock.Price);
        }


        // Gets or sets the stock
        public AStock Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }
    }
}
