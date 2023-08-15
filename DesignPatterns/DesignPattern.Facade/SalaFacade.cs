namespace Facade
{
    //Facade
    public class Sala
    {
        //SubsystemA
        SalaTreinamento s =
            new SalaTreinamento();

        //SubsystemB
        Projetor p =
            new Projetor();

        //SubsystemC
        Computador[] ac =
            new Computador[10];

        public Sala()
        {
            for (int i = 0; i < ac.Length; i++)
            {
                ac[i] = new Computador();
            }
        }

        //Operation1
        public void Abrir()
        {
            s.Abrir();
            s.AcenderLuzes();
            p.Ligar();

            foreach (var item in ac)
            {
                item.Ligar();
            }
        }

        //Operation2
        public void Fechar()
        {
            foreach (var item in ac)
            {
                item.Desligar();
            }

            p.Desligar();
            s.ApagarLuzes();
            s.Fechar();
        }
    }
}
