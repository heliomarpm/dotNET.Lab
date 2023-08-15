using DesignPattern.ChainOfResponsability;

namespace Pattern.ChainOfResponsability
{
    abstract class Aprovar
    {
        protected Aprovar sucessor;

        public void SetSucessor(Aprovar successor)
        {
            this.sucessor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}
