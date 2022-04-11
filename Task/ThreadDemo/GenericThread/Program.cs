using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GenericThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Factory.StartNew<int>(() => CalcSize("Hello World"));


            Task<int> task2 = new Task<int>(() => CalcSize("Hello World"));
            task2.Start();

            // 메인스레드에서 다른 작업 실행
            Thread.Sleep(1000);


            int result = task.Result;

            task2.Wait();
            int result2 = task2.Result;

            Console.WriteLine("Result={0}", result);
            Console.WriteLine("Result2={0}", result2);

        }

        static int CalcSize(string data)
        {
            string s = data == null ? "" : data.ToString();

            //복잡한 계산을 한다고 가정

            return s.Length;
        }
    }
}
