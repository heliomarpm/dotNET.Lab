namespace DesignPattern.Observer.RealWord
{
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    class IBM : AStock
    {
        // Constructor
        public IBM(string symbol, double price)
            : base(symbol, price)
        { }
    }
}
