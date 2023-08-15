/*
 * representa a classe abstrata Colleague. 
 * Mantém uma referência ao seu objeto Mediator e se comunica com o Mediator sempre que necessário, 
 * de outra forma se comunica com um participante;
 */
using System;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// A classe 'AbstractColleague'
    /// </summary>
    public abstract class Participante
    {
        public Participante(string nome)
        {
            this.Nome = nome;
        }

        public string Nome { get; private set; }
        public ChatSala ChatSala { get; set; }

        //Envia mensagem para um dado participante 
        public void Enviar(string para, string mensagem)
        {
            ChatSala.Enviar(this.Nome, para, mensagem);
        }
        //Recebe mensagem de um participante 
        //Public Overridable Sub Receber(ByVal [de] As String, ByVal mensagem As String)
        public virtual void Receber(string de, string mensagem)
        {
            Console.WriteLine("{0} para {1}: '{2}'", de, Nome, mensagem);
        }
    }
}

