using System;

namespace ch7_5_Event
{
    class Program
    {
        delegate void OnClicked();

        static void ButtonPressed(OnClicked clickedFunction)
        {
            clickedFunction();
        }
        static void Main(string[] args)
        {
            
            // 델리게이트는 호출하는 부분을 아무나 호출할 수 있는게 큰 문제가 될 수 있다
            // clickedFunction()이 중요한 부분이고 조심해서 호출해야 한다면 설계가 잘못된 것이다
            
            // Delegate를 Wrapping하는 Event 
        }
    }
}
