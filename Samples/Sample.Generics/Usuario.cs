
namespace Sample.Generics
{
    public class Usuario
    {
        public Usuario()
        {
            //Construtor padrão
        }

        public Usuario(string pNome, string pSexo)
        {
            this.Nome = pNome;
            this.Sexo = pSexo;
        }

        public string Nome { get; set; }
        public string Grupo { get { return string.IsNullOrEmpty(Nome) ? "" : Nome.Substring(0, 1); } }
        public string Sexo { get; set; }

        public override string ToString()
        {
            return string.Format("Grupo: {1} - Nome: {0} - Sexo: {2}", Nome, Grupo, Sexo);
        }

    }
}
