using System;

namespace DesignPattern.Observer.SemPadrao
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
    }



    public class Robo
    {
        private int _fatorPecasPorPedido = 1;
        private LinhaProducao _linhaDeProducao = null;

        public string NomeRobo { get; set; }

        public Robo(string nomeRobo, LinhaProducao linhaDeProducao, int fatorPecasPorPedido)
        {
            this.NomeRobo = nomeRobo;
            this._linhaDeProducao = linhaDeProducao;
            this._fatorPecasPorPedido = fatorPecasPorPedido;
        }

        public void SuprirPecas(int qtItensPedido)
        {
            this._linhaDeProducao.ReceberPecasDoRobo(qtItensPedido * this._fatorPecasPorPedido);
        }

    }

}
