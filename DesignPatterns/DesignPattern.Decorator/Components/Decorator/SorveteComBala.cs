namespace Decorator
{
    //Decorator    
    class SorveteComBala : ISorvete
    {
        //Component : IComponent        
        ISorvete s;

        public SorveteComBala(ISorvete s)
        {
            this.s = s;
        }

        //State        
        public double Preco
        {
            get
            {
                return this.s.Preco + 0.75;
            }
        }
    }
}
