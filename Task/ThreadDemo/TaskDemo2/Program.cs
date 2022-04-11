using System;
using System.Threading.Tasks;

namespace TaskDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(new Action(Run));
            Task t2 = new Task(Run);
            Task t3 = new Task(() =>
            {
                Console.WriteLine("Long query");
            });

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Wait();
            t2.Wait();
            t3.Wait();
        }

        static void Run()
        {
            Console.WriteLine("Long running method");
        }
    }
}
