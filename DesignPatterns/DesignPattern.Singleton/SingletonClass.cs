
namespace Singleton
{
    public sealed class SingletonClass
    {
        private static readonly SingletonClass _instance = new SingletonClass();

        private SingletonClass() { }

        public static SingletonClass GetInstance
        {
            get { return _instance; }
        }
    }
}
