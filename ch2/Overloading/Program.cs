using System;

namespace Overloading
{
    class Program
    {
        // 메소드 오버로딩이란 이름은 같지만 매개변수의 개수나 타입이 다른 메소드를 여러개 만드는 것을 의미
        // 반환 형식(return type)은 오버로딩 조건에 포함되지 않는다

        public int Plus(int a, int b)
        {
            return a + b;
        }
        public double Plus(double a, int b)
        {
            return a + b;
        }

            static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
