using System.Collections.Generic;

namespace Flyweight
{
    public enum Tipo
    {
        quente, frio
    }

    //FlyweightFactory
    public class SanduicheFactory
    {
        //flyweights
        Dictionary<int, ISanduiche> sanduiches = new Dictionary<int, ISanduiche>();

        public SanduicheFactory()
        {
            sanduiches.Clear();
            sanduiches.Add(1, new Hamburger());
            sanduiches.Add(2, new PaoComMortadela());
            sanduiches.Add(3, new Misto() { Tipo = Tipo.frio });
            sanduiches.Add(4, new Misto() { Tipo = Tipo.quente });
        }

        public ISanduiche this[int index]
        {
            get
            {
                return sanduiches[index];
            }
        }
    }


}
