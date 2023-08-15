using System;

namespace DesignPattern.Observer.ComPadraoOtimizado
{

    public class Pedido
    {
        public Pedido(int qtPedido)
        {
            this.QtPedido = qtPedido;
        }

        public int QtPedido { get; set; }
    }



    /// <summary>
    /// Delegate responsável por "segurar" os pedidos de notificacao de alteracao
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="sender"></param>
    /// <param name="eventArgs"></param>
    public delegate void NovoPedidoEventHandler<T, U>(T sender, U eventArgs);


    /// <summary>
    /// Classe responsável por transitar as informações do evento
    /// </summary>
    public class PedidoEventArgs : EventArgs
    {
        public PedidoEventArgs(int qtPedido)
        {
            this.QtPedido = qtPedido;
        }

        public int QtPedido { get; set; }
    }


    public class LinhaProducao
    {
        /// <summary>
        /// Evento
        /// </summary>
        public event NovoPedidoEventHandler<LinhaProducao, PedidoEventArgs> Novo;


        /// <summary>
        /// método responsável por invocar o evento de novo pedido
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnNovo(PedidoEventArgs e)
        {
            if (Novo != null)
            {
                Novo(this, e);
            }
        }


        /// <summary>
        /// Liga um robô em uma linha de produção
        /// </summary>
        /// <param name="robo"></param>
        public void AtivarRobo(Robo robo)
        {
            //assina o evento fazendo o robô ser notificado a cada novo pedido
            /* 
             * aqui é possível chamar o evento robo.SuprirPecas pois ele tem a mesma
             * assinatura do delegate  NovoPedidoEventHandler<T, U> (T sender, U eventArgs);
             */
            Novo += new NovoPedidoEventHandler<LinhaProducao, PedidoEventArgs>(robo.SuprirPecas);

            Console.WriteLine("Robô {0} plugged", robo.NomeRobo);
        }



        /// <summary>
        /// Retira um robo da lista de "observadores"
        /// </summary>
        /// <param name="robo"></param>
        public void DesativarRobo(Robo robo)
        {
            //remove a assinatura do evento
            Novo -= new NovoPedidoEventHandler<LinhaProducao, PedidoEventArgs>(robo.SuprirPecas);

            Console.WriteLine("Robô {0} unplugged", robo.NomeRobo);
        }



        /// <summary>
        /// Dá entrada de um novo pedido na linha de produção
        /// </summary>
        /// <param name="ped"></param>
        public void AdicionarPedido(Pedido ped)
        {
            OnNovo(new PedidoEventArgs(ped.QtPedido));
        }


        public void ReceberPecasDoRobo(int qtPecas)
        {
            Console.WriteLine("Recebi {0} peças para montagem", qtPecas);
        }

    }



    public class Robo
    {

        private int _fatorPecasPorPedido = 1;

        public string NomeRobo { get; set; }


        public Robo(string nomeRobo, int fatorPecasPorPedido)
        {
            this.NomeRobo = nomeRobo;
            this._fatorPecasPorPedido = fatorPecasPorPedido;
        }



        /// <summary>
        /// para poder ser chamado pelo evento, esse método deve ter a mesma assinatura do delegate
        /// </summary>
        /// <param name="linhaDeProducao"></param>
        /// <param name="e"></param>
        public void SuprirPecas(LinhaProducao linhaDeProducao, PedidoEventArgs e)
        {
            linhaDeProducao.ReceberPecasDoRobo(e.QtPedido * this._fatorPecasPorPedido);
        }


    }

}
