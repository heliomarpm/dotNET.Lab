using System;

namespace DesignPattern.Factory
{
    public enum EDirecaoAndar
    {
        Frente,
        Traz,
        Esquerda,
        Direita
    }

    public enum EGirar
    {
        Esquerda,
        Direita
    }

    public enum EModo
    {
        veiculo,
        robo
    }

    public abstract class RoboAbstract
    {
        protected String Nome { get; set; }
        protected EModo Modo { get; set; }

        public void Andar(EDirecaoAndar Direcao, int passos)
        {
            Console.WriteLine("O robo {0} está andando para {1} {2} passo(s)", this.Nome, Direcao.ToString(), passos);
        }

        public void Girar(EGirar Movimento, int grau)
        {
            Console.WriteLine("O robo {0} está girando para {1} {2}º", this.Nome, Movimento.ToString(), grau);
        }

        public abstract void Transformar();
        public abstract void Script(int Numero);

    }



}

