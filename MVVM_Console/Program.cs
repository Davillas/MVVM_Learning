using System;
using System.Threading;
namespace MVVM_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";

            var thread = new Thread(ThreadMethod);
            thread.Name = "Secondary Thread";
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.AboveNormal;

            thread.Start(42);

            var cnt = 5;
            var msg = "Hi!";
            var timeout = 150;

            new Thread(() => PrintMethod(msg, cnt, timeout)) {IsBackground = true}.Start();

            CheckThread();
            Console.ReadLine();
        }

        private static void PrintMethod(string Message, int Count, int Timeout)
        {
            for (var i = 0; i < Count; i++)
            {
                Console.WriteLine(Message);
                Thread.Sleep(Timeout);
            }

        }

        public static void ThreadMethod(object parameter)
        {
            var value = (int)parameter;
            Console.WriteLine(value);

            CheckThread();
        }

        private static void CheckThread()
        {
            
            var thread = Thread.CurrentThread;
            Console.WriteLine("{0}:{1}" , thread.ManagedThreadId, thread.Name);
        }
    }
}
