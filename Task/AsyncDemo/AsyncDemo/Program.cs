using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 호출자 스레드(메인 스레드)를 Block하지 않는다
            //TaskTest();
            TaskTest2();
            Console.WriteLine("End Main");
            Console.Read();

        }

        static void TaskTest()
        {
            Task.Delay(5000);  // 현재 스레드 중지시키지 않음 
            //Thread.Sleep(5000);  // 현재 스레드 중지시킴
            Console.WriteLine("End AsyncFunc");
        }

        static async void TaskTest2()
        {
            await Task.Delay(5000);
            Console.WriteLine("End AsyncFunc");

        }
    }
}
