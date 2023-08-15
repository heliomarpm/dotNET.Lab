using System.Diagnostics.Contracts;

namespace Sample.CodeContracts
{
    /// <summary>
    /// Code Contracts: criando software verificável em .Net
    /// http://viniciusquaiato.com/blog/code-contracts-criando-software-verificavel-em-net/
    /// </summary>
    public class ContratoVerificavel
    {

        /// <summary>
        /// Divisão por zero ocorre erros, para isso incluimos uma pré condição
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="dividir"></param>
        /// <returns></returns>
        public static int DivisaoComPrecondicao(int valor, int dividir)
        {
            Contract.Requires(dividir > 0);
            return valor / dividir;
        }

    }


    public class Rational
    {

        int numerator;
        int denominator;

        public Rational(int numerator, int denominator)
        {
            Contract.Requires(denominator != 0);

            this.numerator = numerator;
            this.denominator = denominator;
        }

        public int Denominator
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() != 0);
                return this.denominator;
            }
        }

        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(this.denominator != 0);
        }
    }
}