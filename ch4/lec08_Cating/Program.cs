using System;

namespace lec08_Cating
{
    // OOP ( 은닉성 / 상속성 / 다형성 )

    class Player
    {
        protected int hp = 0;
        protected int attack = 0;

    }

    class Knight : Player
    {

    }

    class Mage : Player
    {
        public int mp;
    }

    class Program
    {
        static void EnterGame(Player player)
        {
            bool isMage = (player is Mage);   // 캐스팅 전에 player가 Mage 타입인지 확인
            if (isMage)
            {
                Mage mage = (Mage)player;  // 만약 실수로 mage 타입으로 변환시켜도 문법상으로는 문제가 없어서
                                           // 실행해보기전까지는  문제를 알 수 없다.
                                           // 컴파일 타임에는 부모 타입 변수인 player가 어떤 타입의 객체를 가리키고 있는지 알 수 없고, 런타임 때 코드를 실행해봐야 알 수 있다.
                mage.mp = 10;              // 실행해보면 crash가 남
            }
        }

        static void EnterGame2(Player player)
        {
            Mage mage = (player as Mage);   // as 연산자는 캐스팅에 성공하면 캐스트 결과를 리턴하고, 실패하면 null을 리턴한다.
            if (mage != null)    // null 은 참조하는 타입이 아무것도 가르키지 않는다는 것을 의미
            {
                mage.mp = 10;       
            }

        }
        static void EnterGame3(Player player)
        {
            var temp = (Knight)player;     // 
            Player temp2 = player as Knight;
            //Mage temp3 = (Mage)player;   // 런타임 에러 발생. Knight와 Mage 둘다 Player 객체의 자식이기는 하지만,
                                           //Knight 타입의 객체는 Mage에만 정의되어 있는 멤버들을 담고 있지 않기 떄문에 Mage 타입의 변수로 Knight 타입의 변수를 참조할 수 없다.
            Mage mage = player as Mage;  
            if (mage != null)    
            {
                mage.mp = 10;
            }
        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Mage mage = new Mage();
            Player player = new Player();

            // Mage 타입 -> Player 타입으로 변환할수 있음
            // Player 타입 -> Mage 타입으로 꼭 변환할수 있는건 아님. Knight 타입이 변환된 Player타입일 수도 있기 때문
            // 그래서 한번 더 명시적으로 표시해줘야함

            //Mage m1 = (Mage)p1;  // 부모타입에서 자식타입으로 변환할때는 확실하다면 명시적으로 변환해줘야 한다.
            // 컴파일시 캐스트가 유효한지 여부를 확인할 수 없어 런타임에 프로그램이 뻗을 수 있다.

            // 자식클래스에서 부모 클래스로 변환은 아무 문제가 없음.
            // 부모 클래스에서 자식 클래스로 변환은 case by case.

            EnterGame2(mage);
            Console.WriteLine($"mage.mp : {mage.mp}");


            Player temp = (Player)knight;

            EnterGame3(knight);
            //EnterGame_1(temp);
            //EnterGame_1(player);
            //Console.WriteLine($"mage.mp : {mage.mp}");

        }
    }
}
