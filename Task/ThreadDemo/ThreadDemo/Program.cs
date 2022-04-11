using System;
using System.Threading;

namespace ThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().DoTest();
        }

        void DoTest()
        {
            //Thread t1 = new Thread(new ThreadStart(Run));
            //t1.Start();

            Thread t1 = new Thread(Run);
            t1.Start();

            Thread t2 = new Thread(delegate()
            {
                Run2();
            });
            t2.Start();

            Thread t3 = new Thread(() => Run3());
            t3.Start();

            Helper helper = new Helper();
            Thread t4 = new Thread(helper.HelperRun);
            t4.Start();

        }

        private void Run()
        {
            Console.WriteLine("Run Start");
            Console.WriteLine($"Run Thread {Thread.CurrentThread.ManagedThreadId} : Begin");
            // Do something
            Thread.Sleep(3000);
            Console.WriteLine($"Run Thread{Thread.CurrentThread.ManagedThreadId} : End");
        }

        private void Run2()
        {
            Console.WriteLine("Run2 Start");
            Console.WriteLine($"Run2 Thread{Thread.CurrentThread.ManagedThreadId} : Begin");
            // Do something
            Thread.Sleep(3000);
            Console.WriteLine($"Run2 Thread{Thread.CurrentThread.ManagedThreadId} : End");
        }
        private void Run3()
        {
            Console.WriteLine("Run3 Start");
            Console.WriteLine($"Run3 Thread{Thread.CurrentThread.ManagedThreadId} : Begin");
            // Do something
            Thread.Sleep(1000);
            Console.WriteLine($"Run3 Thread{Thread.CurrentThread.ManagedThreadId} : End");
        }
    }

    class Helper
    {
        public void HelperRun()
        {
            Console.WriteLine("Helper Start");
            Console.WriteLine($"Helper Thread{Thread.CurrentThread.ManagedThreadId} : Begin");
            // Do something
            Thread.Sleep(2000);
            Console.WriteLine($"Helper Thread{Thread.CurrentThread.ManagedThreadId} : End");
        }
    }
}
