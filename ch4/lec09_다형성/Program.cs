using System;

namespace lec09_다형성
{
    // OOP ( 은닉성 / 상속성 / 다형성 )

    class Player
    {
        protected int hp;
        protected int attack;

        public void Move()
        {
            Console.WriteLine("Player 이동!");
        }
    }

    class Knight : Player
    {
        public new void Move()  // Player의 Move를 가리더라도 상관 없다는 것을 알림
        {
            Console.WriteLine("Knight 이동!");
        }
    }

    class Mage : Player
    {
        public int mp;

        public new void Move()
        {
            Console.WriteLine("Player 이동!");
        }
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
                mage.mp = 10;            // 실행해보면 crash가 남
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

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

            knight.Move();
            mage.Move();


            EnterGame2(mage);

        }
    }
}
