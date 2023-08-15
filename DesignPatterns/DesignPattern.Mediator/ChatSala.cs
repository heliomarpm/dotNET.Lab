/*
 * representa a classe concreta ConcreteMediator. 
 * Conhece as classes Participante, mantém uma referência aos objetos Participante e 
 * implementa a comunicação e transferência de mensagens entre os objetos da classes Participante
 */
using System.Collections.Generic;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// A classe concreta 'ConcreteMediator'
    /// </summary>
    public class ChatSala : AbstractChatSala
    {
        private Dictionary<string, Participante> _participantes = new Dictionary<string, Participante>();

        public override void Registro(Participante participante)
        {
            if (!_participantes.ContainsValue(participante))
                _participantes[participante.Nome] = participante;

            participante.ChatSala = this;
        }

        public override void Enviar(string de, string para, string mensagem)
        {
            var participante = _participantes[para];

            if (participante != null)
                participante.Receber(de, mensagem);
        }
    }
}
