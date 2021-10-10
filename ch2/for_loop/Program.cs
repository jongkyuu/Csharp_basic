using System;

namespace for_loop
{
    class Program
    {
        static void Main(string[] args)
        {

            //for ( 초기화식; 조건식; 반복식)
            //       초기화식, 조건식, 반복식을 모두 채울 필요는 없다
            //       조건식은 초기화식 다음에 바로 실행된다.
            //       for ( int i=0; i<0; i++) 인 경우에 
            //       for문은 한번도 실행되지 않고 바로 빠져나간다.

            /*
            for (int i=0; i < 5; i++)
            {
                Console.WriteLine("Hello World!");
            }

            위의 for문과 아래의 while문의 의미가 같음

            int i = 0;
            while ( i < 5)
            {
                Console.WriteLine("Hello World!");
                i++;
            }

            */

            for (int i=0; i<0; i++)
            {
                Console.WriteLine("초기화 Test");
            }

        }
    }
}
