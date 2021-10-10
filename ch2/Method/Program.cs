using System;

namespace Method
{
    class Program
    {

        static void AddOne(ref int num)
        {
            num += 1;
        }

        static int AddOne2(int num)
        {
            return num + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        
        static void Divide(int a, int b, out int result1, out int result2)
        {
            result1 = a / b;
            result2 = a % b;
        }
        static void Main(string[] args)
        {
            //  상용 온라인 게임 프로그램 라인 수가 50만줄 수준
            // 메소드는 항상 Class 안에 있어야한다 

            // 메소드 형태
            // 한정자 반환형식 이름(매개변수목록)


            // ref 키워드를 사용하면 값이 참조로 전달됨을 나타냄
            // 복사는 가품, 참조는 진품을 의미한다고 보면 됨

            int a = 0;

            AddOne(ref a);
            Console.WriteLine(a);

            a = AddOne2(a);
            Console.WriteLine(a);


            // 두가지 버전이 모두 유효하지만 디자인상 두번재 버전이 훨씬 좋음
            // 두번째 버전(AddOne2)에서는 원본의 값을 꼭 바꾸지 않고 다른곳에 저장만 하는 용도로 사용할 수도 있고,
            // 원본의 값을 바꿀 수도 있다.
            // 첫번재 버전(AddOne)은 테스트만 하고 싶어도 원본 값에 무조건 영향을 줌

            // 하지만 원본으로 연산을 해야하는 경우도 있음
            // 두 값을 바꿔주는 Swap 함수의 경우 참조로 넘겨줘야 원본 값을 바꿀 수 있음

            int num1 = 1;
            int num2 = 2;

            Swap(ref num1, ref num2);

            Console.WriteLine($"{num1}, {num2}");


            // ref는 변수를 전달하기 전에 초기화해야 하지만, out을 사용하면 전달하기 전에 초기화 할 필요가 없다
            // out 매개변수는 메서드 내에서 리턴 전에 반드시 값을 지정해 주어야 한다.

            int num3 = 10;
            int num4 = 3;

            //int result1;
            //int result2;

            Divide(num3, num4, out int result1, out int result2);
            Console.WriteLine($"{result1}, {result2}");

        }
    }
}
