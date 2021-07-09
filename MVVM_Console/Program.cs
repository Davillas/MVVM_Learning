using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
namespace MVVM_Console
{
    class Program
    {
        private static bool __ThreadUpdate = true;
        static void Main(string[] args)
        {
            //Thread.CurrentThread.Name = "Main Thread";

            //var thread = new Thread(ThreadMethod);
            //thread.Name = "Secondary Thread";
            //thread.IsBackground = true;
            //thread.Priority = ThreadPriority.AboveNormal;

            //thread.Start(42);

            //var cnt = 5;
            //var msg = "Hi!";
            //var timeout = 150;

            //new Thread(() => PrintMethod(msg, cnt, timeout)) {IsBackground = true}.Start();

            //CheckThread();

            //var values = new List<int>();

            //var threads = new Thread[10];
            //object lock_object = new object();
            //for (var i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(
            //        () =>
            //        {
            //            for (var j = 0; j < 10; j++)
            //                lock(lock_object)
            //                    values.Add(Thread.CurrentThread.ManagedThreadId);

            //        });
            //}

            //foreach (var _thread in threads)
            //    _thread.Start();

            //Mutex mutex = new Mutex();
            //Semaphore semaphore = new Semaphore(0,10);

            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            EventWaitHandle thread_guidance = autoResetEvent;

            //Console.ReadLine();
            //Console.WriteLine(String.Join(",", values));

            var test_threads = new Thread[10];
            for (var i = 0; i < test_threads.Length; i++)
            {
                var local_i = i;
                test_threads[i] = new Thread(() =>
                {
                    Console.WriteLine("Thread ID: {0} Started", Thread.CurrentThread.ManagedThreadId);
                    thread_guidance.WaitOne();
                    Console.WriteLine("Value:{0}", local_i);
                    Console.WriteLine("Thread ID: {0} Finished", Thread.CurrentThread.ManagedThreadId);
                    thread_guidance.Set();
                });
                test_threads[i].Start();
            }

            Console.WriteLine("Ready for starting threads");
            Console.ReadLine();

            thread_guidance.Set();

            Console.ReadLine();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
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
