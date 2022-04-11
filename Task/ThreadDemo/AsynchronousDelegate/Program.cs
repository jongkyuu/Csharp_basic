using System;

namespace AsynchronousDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> work = GetArea;

            // PlatformNotSupportedException 발생
            // .net Core에서는 BeginInvoke 메서드를 지원하지 않음
            IAsyncResult asyncResult = work.BeginInvoke(10, 20, null, null);  
            Console.WriteLine("Do somthing in Main thread");

            int result = work.EndInvoke(asyncResult);
            Console.WriteLine($"Result : {asyncResult}");
        }

        static int GetArea(int height, int width)
        {
            int area = height * width;
            return area;
        }
    }
}
