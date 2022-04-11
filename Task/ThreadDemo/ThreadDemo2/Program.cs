using System;
using System.Threading;

namespace ThreadDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(new ThreadStart(Run));
            Thread t1 = new Thread(Run);
            t1.Start();

            Thread t2 = new Thread(new ParameterizedThreadStart(Calc));
            t2.Start(10.00);

            Thread t3 = new Thread(() => Sum(10, 20, 30));
            t3.Start();

            Thread t4 = new Thread(new ThreadStart(RunBackground));
            t4.IsBackground = true;
            t4.Start();
        }

        static void Run()
        {
            Console.WriteLine($"Run Thread {Thread.CurrentThread.ManagedThreadId} : Begin");
            // Do something
            Thread.Sleep(3000);
            Console.WriteLine($"Run Thread{Thread.CurrentThread.ManagedThreadId} : End");
        }

        static void RunBackground()
        {
            Console.WriteLine($"Run Thread {Thread.CurrentThread.ManagedThreadId} : Begin");
            // Do something
            Thread.Sleep(5000);
            Console.WriteLine($"Run Thread{Thread.CurrentThread.ManagedThreadId} : End");
        }

        static void Calc(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine($"r={r}, area={area}");
        }

        static void Sum(int d1, int d2, int d3)
        {
            int sum = d1 + d2 + d3;
            Console.WriteLine("Sum : {0}", sum);
        }
    }
}
