namespace Facade
{
    //Facade
    public static class HomemFacade
    {
        //SubsystemA
        static Carteira carteira = new Carteira();

        //SubsystemB
        static Pessoa pessoa = new Pessoa();

        //Operation1
        public static void SacarDinheiro()
        {
            pessoa.Ir("caixa eletrônico");
            carteira.Abrir();
            carteira.PegarCartao("débito");
            pessoa.PassarCartao();
            pessoa.DigitarSenha();
            pessoa.PegarDinheiro();
            carteira.GuardarCartao();
            carteira.Guardar("bolso");
            pessoa.Ir("casa");
        }
    }
}
