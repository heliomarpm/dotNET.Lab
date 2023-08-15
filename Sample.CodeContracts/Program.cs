using System;

namespace Sample.CodeContracts
{

    /// <summary>
    /// Code Contracts é o equivalente no .NET a Design by Contract. Infelizmente o termo Design by Contract é uma marca registrada.
    ///     
    /// Estes contratos nos permitem escrever software de uma forma verificável, onde podemos garantir pré-condições, pós-condições e invariantes. 
    /// Me agrada a idéia também de que o código se torna mais claro e limpo. 
    /// Ficam claramente expressas as inteções do código, as regras se tornam explícitas ao invés de 
    /// estarem escondidas em emaranhados de condicionais.Vamos entender então um pouco de Contratos.
    ///     
    ///     Pré-condição é uma condição que deve ser satisfeita, sempre, no início da execução do método 
    /// Geralmente as pré-condições dizem respeito a verificação e garantia de valores para os parâmetros de um método. 
    /// No entanto podem existir outras utilizações.
    /// 
    ///     Pós-condição é uma condição que deve ser garantida ao término da execução do método 
    /// As pós-condições podem ser utilizadas para garantir que um determinado resultado seja retornado 
    /// pelo método ou ainda que um determinado estado na classe tenha sido contemplado.
    /// 
    ///     Invariante é uma condição que deve ser verdadeira ao longo de toda a vida de um objeto. 
    /// Invariante diz respeito a um estado que deve ser mantido durante toda a vida de um objeto, podendo 
    /// por exemplo definir que o valor de um atributo da classe que não pode ter determinado valor nunca.
    /// <links>
    ///     http://viniciusquaiato.com/blog/code-contracts-criando-software-verificavel-em-net/
    ///     http://visualstudiogallery.msdn.microsoft.com/1ec7db13-3363-46c9-851f-1ce455f66970
    /// </links>
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ContratoVerificavel.DivisaoComPrecondicao(10, 0));

            var rat = new Rational(10, 0);

            Console.WriteLine(rat.Denominator);

            Console.Read();
        }
    }
}
