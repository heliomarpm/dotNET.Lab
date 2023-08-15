
namespace DesignPattern.ChainOfResponsability
{
    class Purchase
    {
        #region Constructor

        public Purchase(int number, double amount, string purpose)
        {
            this.Number = number;
            this.Amount = amount;
            this.Purpose = purpose;
        }
        #endregion

        public int Number { get; set; }
        public double Amount { get; set; }
        public string Purpose { get; set; }
    }
}
