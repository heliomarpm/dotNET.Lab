using System;

namespace Flyweight
{
    //Flyweight
    public class Hamburger : SanduicheAbstract
    {
        public override double Preco
        {
            get { return 4.5; }
        }
    }

    //Flyweight
    public class PaoComMortadela : SanduicheAbstract
    {
        public override double Preco
        {
            get { return 1.8; }
        }
    }

    //Flyweight
    public class Misto : SanduicheAbstract
    {
        public override double Preco
        {
            get { return 2.75; }
        }

        public Tipo Tipo { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("{0} {1} - {2:c}", this.GetType().Name, this.Tipo.ToString(), this.Preco);
        }
    }


}
