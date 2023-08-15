using System;

namespace DesignPattern.Factory
{
    public enum ERobos
    {
        C6PO,
        Optimus_Prime,
        Bumblebee
    }


    public class C6PO : RoboAbstract
    {
        public C6PO()
        {
            this.Nome = "C6PO";
            this.Modo = EModo.robo;
        }

        public override void Transformar()
        {
            Console.WriteLine("{0} não tem opção de se transformar!", this.Nome);
            //this.Modo = (this.Modo == EModo.veiculo ? EModo.robo : EModo.veiculo);
        }

        public override void Script(int Numero)
        {
            this.Andar(EDirecaoAndar.Frente, 20);
            this.Girar(EGirar.Esquerda, 90);
            this.Andar(EDirecaoAndar.Frente, 100);
            this.Girar(EGirar.Direita, 19);
        }
    }


    public class Optimus_Prime : RoboAbstract
    {
        public Optimus_Prime()
        {
            this.Nome = "Optimus_Prime";
            this.Modo = EModo.veiculo;
        }


        public override void Transformar()
        {
            this.Modo = (this.Modo == EModo.veiculo ? EModo.robo : EModo.veiculo);
            Console.WriteLine("{0} em modo {1}", this.Nome, this.Modo.ToString());
        }

        public override void Script(int Numero)
        {

            switch (Numero)
            {
                case 1:
                    if (this.Modo == EModo.veiculo)
                        this.Transformar();

                    this.Girar(EGirar.Esquerda, 25);
                    this.Andar(EDirecaoAndar.Esquerda, 2);
                    this.Andar(EDirecaoAndar.Frente, 10);

                    break;
            }
        }

    }



    public class Bumblebee : RoboAbstract
    {
        public Bumblebee()
        {
            this.Nome = "Bumblebee";
            this.Modo = EModo.veiculo;
        }

        public override void Transformar()
        {
            this.Modo = (this.Modo == EModo.veiculo ? EModo.robo : EModo.veiculo);
            Console.WriteLine("{0} em modo {1}", this.Nome, this.Modo.ToString());
        }

        public override void Script(int Numero)
        {
            switch (Numero)
            {
                case 1:
                    if (this.Modo == EModo.veiculo)
                        this.Transformar();

                    this.Girar(EGirar.Direita, 1);
                    this.Andar(EDirecaoAndar.Esquerda, 2);
                    this.Andar(EDirecaoAndar.Frente, 1);

                    break;

                case 2:
                    if (this.Modo == EModo.veiculo)
                        this.Transformar();

                    this.Andar(EDirecaoAndar.Frente, 15);
                    this.Andar(EDirecaoAndar.Direita, 4);
                    this.Girar(EGirar.Direita, 180);
                    this.Andar(EDirecaoAndar.Frente, 2);

                    break;

                case 3:
                    if (this.Modo == EModo.veiculo)
                        this.Transformar();

                    Console.WriteLine("{0} fez alguns passos de samba.", this.Nome);

                    break;
            }

        }

    }


}
