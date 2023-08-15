/*
 * representa a classe ConcreteColleague e herda de Participante
 */
using System;

namespace DesignPattern.Mediator
{
    /// <summary>
    /// A classe 'ConcreteColleague'
    /// </summary>
    public class Membro : Participante
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome"></param>
        public Membro(string nome)
            : base(nome)
        {
            Console.Write(string.Concat("Membro : ", base.Nome));
        }

        /// <summary>
        /// sobrescreve o método Receber
        /// </summary>
        /// <param name="de"></param>
        /// <param name="mensagem"></param>
        public override void Receber(string de, string mensagem)
        {
            Console.Write("para Membro : ");
            base.Receber(de, mensagem);
        }
    }
}
