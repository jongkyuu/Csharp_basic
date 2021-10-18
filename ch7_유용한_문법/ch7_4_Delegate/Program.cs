using System;

namespace ch7_4_Delegate
{
    class Program
    {
        // UI
        // 
        static void ButtonPressed() // 버튼이 눌러지면
        {
            // 어떤 버튼인지 체크해서 player를 공격시킨다
            // PlayerAttack();
        }

        // 이런식으로 만들면 설계적인 문제, 현실적인 문제가 있다
        // 설계적인 문제는 
        // 버튼이 눌렸을때 실행되어야 할 함수를 여기에 다 넣어놓으면 UI 와 관련된 로직과 게임 로직이 얽히게 된다
        // 최대한 UI 코드와 게임 로직 관련 코드를 분리시켜 관리하는게 장기적인 차원에서 좋다
        // 현실적인 문제는
        // ButtonPressed() 같은 메서드가 수정할 수 없는 방식으로 배포되는 경우가 많음
        // 유니티 엔진의 코어한 엔진 부분까지 수정할 수 없음.
        // 따라서 버튼이 눌러졌을때 어떤 행동을 한다고 코드를 짤 수 없는 문제가 발생.
        // 버튼이 눌러졌을 때 호출해야 하는 행위(함수 자체)를 인자로 넘겨주고 싶은 상황을 생김

        static void ButtonPressed_2(/*함수 자체를 인자로 넘겨줌*/)
        {
            // 함수를 호출();  
            // 함수 자체를 인자로 넘겨주고 나중에 필요할 때 안쪽에서 함수를 역으로 호출하는것을 콜백(CallBack) 방식이라고 한다
        }

        delegate int OnClicked();  // 함수가 아니라 형식임. OnClicked 이라는 이름을 가지고 매개변수가 없고, int를 리턴 타입으로 가지는 delegate 형식을 선언
                                   // delegate가 붙으면 형식은 형식인데 함수 자체를 인자로 넘겨주는 형식으로 이해
                                   // 반환 : int , 입력 : void
                                   // OnClicked는 delegate 형식의 이름

        static void ButtonPressed_3(OnClicked clickedFuntion)
        {
            clickedFuntion(); // 필요할때 clickedFuntion()을 호출
            //clickedFuntion.Invoke();
        }

        // 인자로 넣을 함수를 OnClicked 과 똑같은 형식으로 민들어줌
        static int TestDelegate()
        {
            Console.WriteLine("Hello Delegate");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("Hello Delegate2");
            return 0;
        }

        // Sorting 함수를 만들때 비교하는 부분만 Delegate로 받으면 다양한 방식으로 동작하도록 만들 수 있다

        static void Main(string[] args)
        {
            // delegate(대리자)

            ButtonPressed_2(/*함수를 인자로 넣어줌*/);
            ButtonPressed_3(TestDelegate);  // OnClicked과 같은 형식의 함수를 인자로 넘겨줌
                                            // C++의 함수 포인터랑 비슷함. 함수자체의 주소에 참조를 넘겨준것 같은 느낌
            // 실제 내부적으로는 아래와 같이 구현됨
            // OnClicked 타입의 객체를 만듬
            // 이렇게 객체를 만들면 델리게이트 체이닝을 할 수 있음
            OnClicked clicked = new OnClicked(TestDelegate);  // 여기에 콜백 함수를 넣어줌
            clicked += TestDelegate2;
            //clicked.Invoke();  // Invoke 메서드를 호출하거나
            //clicked(); // 함수를 호출하듯이 직접 이렇게 호출하거나
            //ButtonPressed_3(clicked);
        }
    }
}
