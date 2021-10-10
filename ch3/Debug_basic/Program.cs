using System;

namespace Debug_basic
{
    class Program
    {
        static void ConsolePrint(int result)
        {
            Console.WriteLine(result);
        }
        static int AddAndPrint(int a,  int b)
        {

            int result = a + b;
            Program.ConsolePrint(result);
            return result;
        }
        static void Main(string[] args)
        {
            // 보통 프로그래밍 시간보다 디버깅 시간이 더 길다 (3:7 정도)
            // 프로시져 단위 실행
            // 프로시져는 메소드와 같은 의미. 메소드 단위로 실행
            // 함수안으로 들어가지 않고 함수 단위로 실행하겠다는 의미

            // 조사식에서 현재 들어가 있는 값을 볼 수 있음
            // 조사식에서 현재 값을 바꿀 수도 있음

            // 호출 스택 창에서 메서드가 호출된 순서를 볼 수 있음
            // 호출 스택은 앱의 실행 흐름을 파악할 수 있는 좋은 방법이다
            // 호출 스택 창에서 다른 스택 프레임으로 전환할 수 있음

            // 디버깅시 조건을 걸어서 특정 조건에서만 중단점이 작동하도록 할 수 있음

            int result = Program.AddAndPrint(10, 20);
        }
    }
}
