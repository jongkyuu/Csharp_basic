using System;

namespace lec08_Cating
{
    // OOP ( 은닉성 / 상속성 / 다형성 )
    // 다형성(Polymorphism) : 여러가지 모습을 가지고 있음. 타입에 따라 다양한 행동을 하기 위해 사용
    class Player
    {
        protected int hp;
        protected int attack;
        public virtual void Move()
        {
            Console.WriteLine("Player Move!");
        }

    }

    // 오버로딩 : 함수 이름의 재사용
    // 오버라이딩 : 다형성을 이용한 문법 
    // override 키워드를 사용하기 위해서는 부모 객체에서 virtual로 선언되어 있어야 함
    // virtual 을 사용하면 사용하지 않은 일반 버전보다 성능에 더 부하를 줌 

    class Knight : Player
    {
        public override void Move()   // new를 사용하면 Player의 Move()를 가리고 새로운 Move() 메소드를 만듬
        {
            base.Move(); // 부모 객체의 Move()를 호출. 부모 객체의 메소드를 활용하면서 기능을 추가하고 싶을때 사용.
            Console.WriteLine("Knight Move!");
        }
    }

    class SuperKnight : Player
    {
        public override void Move()   
        {
            Console.WriteLine("SuperKnight Move!");
        }
    }


    class Mage : Player
    {
        public int mp;
        public override void Move()
        {
            Console.WriteLine("Mage Move!");
        }
    }

    class Program
    {

        static void EnterGame(Player player)
        {
            // 다형성을 사용한 버전
            // 객체가 어떤 타입인지 런타임에 체크를 해서 그 타입에 맞는 버전의 함수를 호출함
            player.Move();

            // 다형성을 쓰지 않은 버전
            Mage mage = (player as Mage);   // as 연산자는 캐스팅에 성공하면 캐스트 결과를 리턴하고, 실패하면 null을 리턴한다.
            if (mage != null)    // null 은 참조하는 타입이 아무것도 가르키지 않는다는 것을 의미
            {
                mage.mp = 10;
                mage.Move();
            }

            Knight knight = (player as Knight);  // Knight 버전의 Move를 호출하기 위해서 체크를 위한 형변환을 해야함
            if (knight != null)                  // 타입이 많아질수록(여기서는 직업) 불필요한 형변환이 많아져서 비효율적임 
            {                                    // 그래서 다형성(Polymorphism)이 필요함
                knight.Move();  
            }



        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

            //knight.Move();

            EnterGame(mage);

        }
    }
}
