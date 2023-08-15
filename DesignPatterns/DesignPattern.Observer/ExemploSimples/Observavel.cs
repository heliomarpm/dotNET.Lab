using System;

namespace DesignPattern.Observer.Simples
{
    /// <summary>
    /// classe Observable(Observável) possui um evento nomeado AlgoAconteceu que tem a finalidade de 
    /// disparar para todos os ouvintes(Observador) sempre que o método FazerAlgumaCoisa for executado
    /// </summary>
    public class Observavel
    {

        public event EventHandler AlgoAconteceu;

        public void FazerAlgumaCoisa()
        {
            EventHandler handler = AlgoAconteceu;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }
}
