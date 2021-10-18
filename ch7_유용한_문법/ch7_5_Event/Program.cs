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

        static void OnInputTest()
        {
            Console.WriteLine("Input Received!");
        }
        static void Main(string[] args)
        {

            //델리게이트를 어디서든 호출할 수 있다는 점이 설계상에 큰 문제가 될 수 있다
            //예를들어 델리게이트 형식 OnClicked를 ButtonPressed 함수 안에서만 실행시키기 위해 OnInputTest()를 만들었다고 하자
            //아래처럼 clicked 델리게이트 객제를 만들고 OnInputTest를 콜백 함수로 등록한 뒤 델리게이트 객체를 메서드 호출 파라미터에 넣어준다.
            // 좀 더 정확히는 그 메서드 정보를 갖는 Wrapper 클래스의 객체를 다른 메서드의 입력 파라미터로 전달하는 것이다
            // 전달받은 델리게이트 객체를 Invoke() 메서드를 사용해 실제 메서드를 호출하거나 Invoke를 생략하고 직접 함수를 호출한다.

            OnClicked clicked = new OnClicked(OnInputTest);
            ButtonPressed(clicked);

            // ButtonPressed() 함수 내부에서 clicked 델리게이트가 정상적으로 실행되었다.
            // 하지만 clicked 델리게이트는 아래처럼 외부에서 직접 호출할 수도 있고, 이를 막을 방법이 없다.
            clicked();

            // Event는 delegate와 달리 이벤트와 같은 클래스 안에서만 이벤트 호출이 가능하다.
            // 외부에서는 오직 이벤트에 함수 등록만 해놓을 수 있으며, 이벤트가 정의된 클래스 외부에서는 이벤트를 호출 할 수 없다. 이것이 델리게이트와의 차이점!!
            // Delegate를 Wrapping하는 Event 

            InputManager inputManager = new InputManager();
            inputManager.InputKey += OnInputTest;  // 구독 신청

            while (true)
            {
                inputManager.Update();  // 알림 보내기
            }

            // Delgate와 달리 아래처럼 직접 InputKey()를 호출할 수가 없음
            // inputManager.InputKey();
        }
    }
}
