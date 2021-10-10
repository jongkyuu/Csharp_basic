using System;

namespace lec07_은닉성
{

    // OOP( 은닉성/ 상속성 / 다형성 )

    // 자동차
    // 핸들, 페달, 문

    // 엔진 조정 등은 사용자가 접근할 수 없게 숨겨져 있다.
    // 중요한 정보라서 함부로 고치면 안되면 모두가 접근할 수 있게 열어두면 안된다. 

    class Knight
    {
        // 접근 한정자
        // public : 모든 외부에서 이 타입을 엑세스할수 있다. 
        // private 동일 클래스/구조체 내의 멤버만 접근 가능하다
        // protected : 파생 클래스에서 이 클래스의 멤버를 엑세스할 수 있다.

        private int hp;

        public void SetHp(int hp)
        {
            this.hp = hp;
        }

        // 왜 hp는 외부에서 접근을 못하게 하고 SetHp 함수를 통해 접근해서 수정하도록 했는지 ?
        // hp를 public 으로 하면 코드가 점점 커질때 누가 hp를  수정했는지 찾기가 힘들다
        // 하지만 모두가 SetHp 함수를 통해 hp를 수정하면 this.hp = hp;에 브레이크 포인트를 잡고 실행해서
        // 호출 스택을 보고 쉽게 판단할 수 있음

        public void SecretFunction()   // 외부에서 접근하면 안되는 기능인데 public 으로 선언하면 안됨
        {
            // 프로그램이 커질수록 많은 개발자가 모여서 작업할 확률이 높음
            // 다른 사람들이 만든 코드들을 다 이해하면서 쓰는게 아니라 
            // 대충 함수 이름만 보고 기능을 예측하는 경우가 많다.
            // 보안 레벨을 모두에게 공유했다는 의미는 다른 개발자가 마음놓고 써도 문제없는 기능이라는 가정이 포함
            // 보안 레벨은 설계를 할때 건드리면 위험한건지 대충 사용해도 되는지를 판가름하는 기준이 된다.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
