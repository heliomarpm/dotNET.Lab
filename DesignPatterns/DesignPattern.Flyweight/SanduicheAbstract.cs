using System;

namespace Flyweight
{

    public abstract class SanduicheAbstract : ISanduiche
    {

        #region ISanduiche Members

        public abstract double Preco { get; }

        #endregion

        public override string ToString()
        {
            return String.Format("{0} - {1:c}", this.GetType().Name, this.Preco);
        }
    }
}
