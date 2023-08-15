using System;
using System.Collections.Generic;

namespace Polimorfismo
{
    public enum eTipoBacktest
    {
        Um,
        Dois
    }

    public class Backtest
    {
        public Dictionary<eTipoBacktest, FamiliaBacktestBase> Familia { get; set; }

        public void Run()
        {
            this.Familia = new Dictionary<eTipoBacktest, FamiliaBacktestBase>()
            {
                { eTipoBacktest.Um, new FamiliaBacktestBase(eTipoBacktest.Um) },
                { eTipoBacktest.Dois, new FamiliaBacktestBase(eTipoBacktest.Dois) }
            };

            Console.WriteLine(this.Familia[eTipoBacktest.Um].ToString());
            Console.WriteLine(this.Familia[eTipoBacktest.Dois].ToString());

            var fbtest = new FbTest1(eTipoBacktest.Um);

            Console.WriteLine(fbtest.ToString());

            Console.Read();
        }
    }

    public class FamiliaBacktestBase
    {
        public int PrazoD0 { get; set; }
        public int PrazoD1 { get; set; }

        public virtual void CalcularPrazo(eTipoBacktest tipoBacktest)
        {
            this.PrazoD0 = DateTime.Now.Day;
            this.PrazoD1 = DateTime.Now.Day - (tipoBacktest == eTipoBacktest.Um ? 0 : 1);
        }

        public override string ToString()
        {
            return $"D0: {this.PrazoD0} / D-1: {this.PrazoD1}";
        }

        public FamiliaBacktestBase(eTipoBacktest tipoBacktest)
        {
            this.CalcularPrazo(tipoBacktest);
        }

    }

    public class FbTest1 : FamiliaBacktestBase
    {
        public FbTest1(eTipoBacktest tipoBacktest) : base(tipoBacktest)
        {
        }
    }

}
