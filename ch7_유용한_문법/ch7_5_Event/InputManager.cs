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
        // 사용자가 a 라는 키를 누르면 알고싶어 하는 모든 사람에게 알려주는 코드
        public void Update()
        {
            if (Console.KeyAvailable == false)
                return; // 아무것도 입력 안한 경우 return

             ConsoleKeyInfo info = Console.ReadKey();
             if (info.Key == ConsoleKey.A)
             {
                // 모두에게 알려준다!

             }
        }
    }
}
