using System;
using System.Runtime.CompilerServices;

namespace ch7_7_Exception
{
    class Program
    {
        // 직접 예외를 정의해서 처리할 수도 있다
        class CustomExeption : Exception
        {

        }
        static void Main(string[] args)
        {
            // 게임에서는 예외처리를 잘 하지 않는 편이다
            // 크래쉬된 채로 보통 놔두고 문제가 되는 코드 자체를 나중에 수정하는게 보통이다
            // 게임의 경우에도 네크워크 오류 같은 문제는 예외 처리가 필요함
            // 1. 0으로 나눌때
            // 2. 참못된 메모리를 참조하는 경우( null을 가진 참조형 변수에 접근, casting 잘못해서 잘못된 타입으로 가지고 있는 경우
            // 3. 오버플로우 (스택이나 힙 영역을 잘못 건드렸을때, 너무 많은 용량을 복사했을 떄)

            int a = 10;
            int b = 0;
            //int result = a / b; // System.DivideByZeroException 발생

            try
            {
                int result = a / b;

                // 위에서 예외가 발생했으면 아래 부분은 실행되지 않음
                int c = 0;
            }
            // Exception 클래스 모든 예외 클래스들의 조상이다. 따라서 모든 예외를 다 받을 수 있다
            // 예외처리를 세분화 할 수도 있다.
            catch (DivideByZeroException e) // 0으로 나눈 경우는 DivideByZeroException라는 특정 타입이 있으니 여기에 걸림. 다음 catch 문은 실행되지 않음
            {

            }
            catch (Exception e) //Attempted to divide by zero
            {
                // 예상하지 못한 일이 발생했을 때 여기서 처리하면 된다
            }
            finally // 예외가 발생해도 무조건 실행해야 하는 부분은 여기 넣어준다. 파일 입출력이나 DB 연결의 경우 연결을 해제하는 등 정리가 필요할 수 있다.
            {

            }

            // 사용자 정의 Exception 처리해보기

            static void CustomFunc()
            {
                throw new CustomExeption();
            }

            try
            {
                CustomFunc();
            }
            catch(Exception e)
            {
                Console.WriteLine("CustomException 발생");
            }
        }
    }
}
