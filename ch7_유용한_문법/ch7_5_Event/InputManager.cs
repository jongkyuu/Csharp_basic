using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch7_5_Event
{
    // 사용자가 키보드나 마우스 입력하는걸 캐치해서 다른 게임 로직이나 프로그램에 알려주는 중간 매개 역할을 하는 클래스
    class InputManager
    {
        public delegate void OnInputKey();

        // OnInputKey inputKey = new OnInputKey(/*함수를 인자로 넘겨줌*/);  // 이런식으로 만들어도 되지만 이번에는 Event를 사용
        public event OnInputKey InputKey;  // 외부에서 사용할거라 대문자로 선언(이건 개인 스타일)

        // 사용자가 a 라는 키를 누르면 알고싶어 하는 모든 사람에게 알려주는 코드
        public void Update()
        {
            if (Console.KeyAvailable == false)
                return; // 아무것도 입력 안한 경우 return

             ConsoleKeyInfo info = Console.ReadKey();
             if (info.Key == ConsoleKey.A)
             {
                // 모두에게 알려준다!
                // 모두에게 알려주는 이 부분을 어떻게 만들어주느냐가 고민
                // 여기에 코드를 직접 넣는건 비효율적인 방식이고, InputManger라는 코드에 의존성을 증가시킴
                // 이때 사용하는것이 콜백 방식 
                InputKey(); // 모두에게 알려줄때는 InputKey()를 호출하면 메세지를 전체적으로 뿌리고,
                            // 이벤트에 관심 있는 사람들은 InputKey를 구독하면 메세지를 받을 수 있다
            }
        }

        // 구독자를 모집하고 특정 이벤트가 발생했을 때 구독자들에게 메세지를 발송하는 방식을 옵저버 패턴(Observer Pattern)이라고 부름
    }
}
