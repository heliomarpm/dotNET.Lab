using System;
using System.Collections;

namespace DesignPattern.Observer.ComPadrao
{
    public class Pedido
    {
        public Pedido(int qtPedido)
        {
            this.QtPedido = qtPedido;
        }

        public int QtPedido { get; set; }
    }

    public class LinhaProducao
    {
        public void ReceberPecasDoRobo(int qtPecas)
        {
            Console.WriteLine("Recebi {0} peças para montagem", qtPecas);
        }


        /// <summary>
        /// Estou usando ArrayList para que o exemplo seja entendível por quem
        /// não programa em .Net e não tem coleções genéricas
        /// </summary>
        public ArrayList pedidos;

        public ArrayList robosDaLinha;

        public LinhaProducao()
        {
            pedidos = new ArrayList();
            robosDaLinha = new ArrayList();
        }


        /// <summary>
        /// Liga um robô em uma linha de produção
        /// </summary>
        /// <param name="robo"></param>
        public void AtivarRobo(Robo robo)
        {
            robosDaLinha.Add(robo);
        }


        /// <summary>
        /// Retira um robo da lista de "observadores"
        /// </summary>
        /// <param name="robo"></param>
        public void DesativarRobo(Robo robo)
        {
            if (this.robosDaLinha.Contains(robo))
            {
                this.robosDaLinha.Remove(robo);
            }
        }


        /// <summary>
        /// Dá entrada de um novo pedido na linha de produção
        /// </summary>
        /// <param name="ped"></param>
        public void AdicionarPedido(Pedido ped)
        {
            pedidos.Add(ped);

            //notifica todos os robôs que eles preisam trabalhar!
            foreach (Robo robo in robosDaLinha)
            {
                robo.SuprirPecas(this, ped.QtPedido);
            }
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

        public void SuprirPecas(LinhaProducao linhaDeProducao, int qtItensPedido)
        {
            linhaDeProducao.ReceberPecasDoRobo(qtItensPedido * this._fatorPecasPorPedido);
        }

    }

}
