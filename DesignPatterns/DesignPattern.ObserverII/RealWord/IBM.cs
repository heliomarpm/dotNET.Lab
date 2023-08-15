namespace DesignPattern.ObserverII.RealWord
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
