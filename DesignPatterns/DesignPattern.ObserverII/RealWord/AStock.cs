using System;
using System.Collections.Generic;

namespace DesignPattern.ObserverII.RealWord
{
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class AStock
    {
        private string _symbol;
        private double _price;
        private List<IInvestidor> _investors = new List<IInvestidor>();

        // Constructor
        public AStock(string symbol, double price)
        {
            this._symbol = symbol;
            this._price = price;
        }

        public void Attach(IInvestidor investor)
        {
            _investors.Add(investor);
        }

        public void Detach(IInvestidor investor)
        {
            _investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestidor investor in _investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }


        // Gets or sets the price
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        // Gets the symbol
        public string Symbol
        {
            get { return _symbol; }
        }
    }
}
