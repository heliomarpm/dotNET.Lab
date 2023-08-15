using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.ForParallel
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/dd537609.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
    /// http://4glnews.blogspot.com.br/2011/09/task-parallel-paralelismo-com-net.html
    /// </summary>
    public class SampleTask
    {
        public static void Run()
        {
            TaskDemo2();

            Console.Read();
        }

        class MyCustomData
        {
            public long CreationTime;
            public int Name;
            public int ThreadNum;
        }

        static void TaskDemo2()
        {
            Task[] taskArray = new Task[10];

            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = new Task((obj) =>
                {
                    MyCustomData mydata = (MyCustomData)obj;
                    mydata.ThreadNum = Thread.CurrentThread.ManagedThreadId;

                    Console.WriteLine("Hello from Task #{0} created at {1} running on thread #{2}.",
                                      mydata.Name, mydata.CreationTime, mydata.ThreadNum);
                },
                new MyCustomData() { Name = i, CreationTime = DateTime.Now.Ticks }
                );
                taskArray[i].Start();
            }
        }
    }
}
