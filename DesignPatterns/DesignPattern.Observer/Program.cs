using DesignPattern.Observer.Simples;
using System;
using co = DesignPattern.Observer.ComPadrao;
using coo = DesignPattern.Observer.ComPadraoOtimizado;
using so = DesignPattern.Observer.SemPadrao;

namespace DesignPattern.Observer
{
    /// <summary>
    /// O padrão Observer cria uma dependência de um-para-muitos entre 
    /// objetos de tal forma que quando o estado de um objeto 
    /// é modificado, suas dependências sejam automaticamente notificadas.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Real World ****");
            SampleRealWorld.Run();
            Console.WriteLine("");
            Console.WriteLine("**** Structural ****");
            SampleStructural.Run();

            ExemploSemPadrao();

            ExemploComPadraoBasico();

            ExemploComPadraoOtimizado();

            ExemploSimples();

            Console.ReadKey();
        }

        private static void ExemploSimples()
        {
            Console.WriteLine("********* MEU EXEMPLO FAVORITO (INICIO) ***********\n");

            Observador observador = new Observador();
            Observavel observavel = new Observavel();
            Observavel observavel2 = new Observavel();


            observavel.AlgoAconteceu += new EventHandler(observavel_AlgoAconteceu); //+= 
            observavel.FazerAlgumaCoisa();

            // -- ou --

            observavel2.AlgoAconteceu += observador.HandleEvent;
            observavel2.FazerAlgumaCoisa();

            Console.WriteLine("********* MEU EXEMPLO FAVORITO (FIM) ***********\n");
        }

        static void observavel_AlgoAconteceu(object sender, EventArgs e)
        {
            Console.WriteLine("algo Aconteceu com " + sender);
        }

        private static void ExemploSemPadrao()
        {
            Console.WriteLine("********* EXEMPLO SEM PADRÃO (INICIO) ***********\n");

            var linha1 = new so.LinhaProducao();

            var wallE = new so.Robo("Wall-E", linha1, 1);
            var c3po = new so.Robo("C3PO", linha1, 10);
            var sonny = new so.Robo("Sonny", linha1, 20);
            var terminator = new so.Robo("Terminator 800", linha1, 1000);

            //entrou novo pedido de 10 peças
            var ped = new so.Pedido(10);

            // põe o povo para trabalhar
            wallE.SuprirPecas(ped.QtPedido);
            c3po.SuprirPecas(ped.QtPedido);
            sonny.SuprirPecas(ped.QtPedido);

            Console.WriteLine("********* EXEMPLO SEM PADRÃO (FIM) ***********\n");
        }

        /// <summary>
        /// Perceba que agora os robôs são "amarrados" à linha de produção 
        /// e cada vez que um pedido é colocado na linha de produção, os robôs são automaticamente "notificados". 
        /// É uma solução muito mais coerente do ponto de vista da OO, já que a 
        /// responsabilidade de saber o que fazer a cada novo pedido é da linha de produção e não de quem colocou o pedido.
        /// </summary>
        private static void ExemploComPadraoBasico()
        {
            Console.WriteLine("********* EXEMPLO COM PADRAO BASICO (INICIO) ***********\n");

            var wallE = new co.Robo("Wall-E", 1);
            var c3po = new co.Robo("C3PO", 10);
            var sonny = new co.Robo("Sonny", 20);
            var terminator = new co.Robo("Terminator 800", 1000);

            var linha = new co.LinhaProducao();

            linha.AtivarRobo(wallE);
            linha.AtivarRobo(c3po);
            linha.AtivarRobo(sonny);
            linha.AtivarRobo(terminator);

            linha.AdicionarPedido(new co.Pedido(10));

            Console.WriteLine("********* EXEMPLO COM PADRAO BASICO (FIM) ***********\n");

        }


        /// <summary>
        /// O exemplo basico apesar de quase perfeito, podemos melhorar essa solução um pouco mais no .Net  utilizando delegates.
        /// Na realidade todos os eventos no .Net são uma implementação do padrão Observer. 
        /// Perceba no código abaixo que criamos um delegate genérico que irá chamar um método do Robô para fornecer as peças.
        /// Apenas os robôs que “assinaram” o evento de Novo Pedido serão notificados. 
        /// Não precisamos criar nenhuma lista de robôs, o próprio .Net cuida disso para nós.
        /// 
        /// No código também merece atenção o seguinte trecho:
        /// 
        /// if (Novo != null)
        /// {
        ///     Novo(this, e);
        /// }
        /// 
        /// Isso garante que o evento será disparado APENAS se alguém o assinou. Se não fizermos esse controle será disparada uma excessão.
        /// </summary>
        private static void ExemploComPadraoOtimizado()
        {
            Console.WriteLine("********* EXEMPLO COM PADRAO OTIMIZADO (INICIO) ***********\n");

            var wallE = new coo.Robo("Wall-E", 1);
            var c3po = new coo.Robo("C3PO", 10);
            var sonny = new coo.Robo("Sonny", 20);
            var terminator = new coo.Robo("Terminator 800", 1000);

            var linha = new coo.LinhaProducao();

            linha.AtivarRobo(wallE);
            linha.AtivarRobo(c3po);
            linha.AtivarRobo(sonny);
            linha.AtivarRobo(terminator);

            Console.WriteLine("Adiciona novo pedido com todos os robôs ativos");

            linha.AdicionarPedido(new coo.Pedido(10));

            linha.DesativarRobo(terminator);

            Console.WriteLine("Adiciona novo pedido sem um robô");

            linha.AdicionarPedido(new coo.Pedido(5));

            Console.WriteLine("********* EXEMPLO COM PADRAO OTIMIZADO (FIM) ***********\n");

        }
    }
}