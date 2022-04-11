using System;
using System.Threading;

namespace ThreadDemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 쓰레드풀에 있는 쓰레드를 이용, 리턴값이 없을 경우 사용
            ThreadPool.QueueUserWorkItem(Calc);
            ThreadPool.QueueUserWorkItem(Calc, 10.0);
            ThreadPool.QueueUserWorkItem(Calc, 20.0);

            Console.ReadLine();
        }

        static void Calc(object radius)
        {
            if (radius == null)
            {
                return;
            }

            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine("r={0}, area={1}", r, area);
        }
    }
}
