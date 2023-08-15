/*
 * representa a classe ConcreteColleague e herda de Participante
 */
using System;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// A classe 'ConcreteColleague'
    /// </summary>
    class NaoMembro : Participante
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome"></param>
        public NaoMembro(string nome)
            : base(nome)
        {
            //base.Nome = nome;
            Console.Write(string.Concat("NaoMembro : ", base.Nome));
        }

        /// <summary>
        /// sobrescreve o método Receber
        /// </summary>
        /// <param name="de"></param>
        /// <param name="mensagem"></param>
        public override void Receber(string de, string mensagem)
        {
            Console.Write("Para NaoMembro : ");
            base.Receber(de, mensagem);
        }
    }
}
