/*
 * representa a classe Mediator. Define uma interface para comunicação com os objetos Participante
 */

namespace DesignPattern.Mediator
{
    /// <summary>
    /// A classe abstrata 'Mediator'
    /// </summary>
    public abstract class AbstractChatSala
    {
        public abstract void Registro(Participante participante);
        public abstract void Enviar(string de, string para, string mensagem);
    }
}
