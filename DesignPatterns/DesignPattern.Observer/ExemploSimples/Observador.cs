using System;

namespace DesignPattern.Observer.Simples
{
    /// <summary>
    /// Classe Observer(Observador) possui um método chamado HandleEvent que pretende observar 
    /// alguma mudança no mundo externo, então ele sempre será invocado quando alguem chamar 
    /// </summary>
    public class Observador
    {
        public void HandleEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Algo aconteceu para " + sender);
        }

    }
}
