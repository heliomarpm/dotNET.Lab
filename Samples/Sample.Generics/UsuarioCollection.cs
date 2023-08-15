using System.Collections;

namespace Sample.Generics
{
    public class UsuarioCollection : CollectionBase
    {
        public int Add(Usuario u)
        {
            return base.List.Add(u);
        }

        public bool Contains(Usuario u)
        {
            return base.List.Contains(u);
        }

        public void Insert(int index, Usuario u)
        {
            base.List.Insert(index, u);
        }

        public Usuario this[int index]
        {
            get { return (Usuario)base.List[index]; }
            set { base.List[index] = value; }
        }

        public void Remove(Usuario u)
        {
            base.List.Remove(u);
        }

    }
}
