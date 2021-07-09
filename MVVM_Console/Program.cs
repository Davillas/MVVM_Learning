using System;
using System.Collections.Generic;
using System.Threading;
namespace MVVM_Console
{
    class Program
    {
        private static bool __ThreadUpdate = true;
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";

            var thread = new Thread(ThreadMethod);
            thread.Name = "Secondary Thread";
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.AboveNormal;

            thread.Start(42);

            //var cnt = 5;
            //var msg = "Hi!";
            //var timeout = 150;

            //new Thread(() => PrintMethod(msg, cnt, timeout)) {IsBackground = true}.Start();

            //CheckThread();

            var values = new List<int>();

            var threads = new Thread[10];
            object lock_object = new object();
            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(
                    () =>
                    {
                        for (var j = 0; j < 10; j++)
                            lock(lock_object)
                                values.Add(Thread.CurrentThread.ManagedThreadId);

                    });
            }

            foreach (var thread in threads)
                thread.Start();



            Console.ReadLine();
            Console.WriteLine(String.Join(",", values));
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

            while (__ThreadUpdate)
            {
                Thread.Sleep(100);
                Console.Title = DateTime.Now.ToString();
            }
                

        }

        private static void CheckThread()
        {
            
            var thread = Thread.CurrentThread;
            Console.WriteLine("{0}:{1}" , thread.ManagedThreadId, thread.Name);
        }
    }
}
