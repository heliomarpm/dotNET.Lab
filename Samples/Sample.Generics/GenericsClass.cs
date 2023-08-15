using System.Collections;

namespace Sample.Generics
{
    /// <summary>
    /// where T : struct – Onde T seja uma estrutura
    /// where T : class – Onde T seja uma classe
    /// where T : new() – Onde T possua um construtor default
    /// where T : U – Onde T herde de U
    /// where T : <nome da classe> – Onde T herde de uma classe específica
    /// where T : <nome da interface> – Onde T implemente uma interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericClassWithWhere<T> where T : class
    {
        public T Entidade { get; set; }
    }

    class GenericClass<T>
    {
        public T Valor { get; set; }
    }

    class GenericHeranca<T> : Usuario
    {
        public int Idade { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - Idade: {1}", base.ToString(), Idade);
        }
    }

    /// <summary>
    /// Coleção Generica apenas para objetos tipo Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericCollection<T> : CollectionBase where T : class
    {
        public int Add(T c)
        {
            return base.List.Add(c);
        }

        public bool Contains(T c)
        {
            return base.List.Contains(c);
        }

        public void Insert(int index, T c)
        {
            base.List.Insert(index, c);
        }

        public T this[int index]
        {
            get { return (T)base.List[index]; }
            set { base.List[index] = value; }
        }

        public void Remove(T c)
        {
            base.List.Remove(c);
        }
    }

    class UsuarioHeranca : GenericHeranca<Usuario>
    {
        public override string ToString()
        {
            return "UsuarioHeranca :" + base.ToString();
        }
    }
}
