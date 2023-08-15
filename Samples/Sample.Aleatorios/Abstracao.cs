using System;

namespace Sample.Aleatorios
{
    interface IMyClass
    {
        void Execute(int jobId);
    }

    abstract class MyClassBase : IMyClass
    {
        public MyClassBase(int jobId)
        {
            Console.WriteLine($"Validação {jobId}");
            if (jobId == 2)
            {
                Console.WriteLine($"Cancelar {jobId}");
                return;
            }
            Execute(jobId);
        }

        public abstract void Execute(int jobId);
    }

    class Concreta : MyClassBase
    {
        public Concreta(int jobId) : base(jobId)
        { }

        public override void Execute(int jobId)
        {
            Console.WriteLine($"Execute {jobId}");
        }
    }

    public class Abstracao
    {
        public static void Run()
        {
            new Concreta(1).Execute(1);
            new Concreta(2).Execute(2);
            new Concreta(3).Execute(3);

            Console.Read();
        }
    }
}
