using System;

namespace Singleton
{

    public sealed class SingletonMultiThred
    {
        private static volatile SingletonMultiThred _instance;
        private static object _syncRoot = new Object();

        private SingletonMultiThred() { }


        public static SingletonMultiThred Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SingletonMultiThred();
                    }
                }

                return _instance;
            }
        }
    }

}
