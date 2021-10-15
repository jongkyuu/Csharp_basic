using System;

namespace ch7_2_Interface
{
    class Monster
    {
        public virtual void Shout() { } // 몬스터는 무조건 shout 기능이 있어야함. 가상함수로 shout 정의. 
    }

    class Orc : Monster
    {
        public override void Shout()
        {
            Console.WriteLine("Orc Shout!");
        }
    }

    class Skeleton : Monster
    {
        public override void Shout()  // Shout를 만들지 않아도 문법적으로 오류는 없음. 자식 클래스에서 Shout의 구현은 선택이다.
        {
            Console.WriteLine("Skeleton Shout!");
        }
    }

    // Shout의 구현을 강제하고 싶을때는 abstract 사용

    abstract class Monster2    // abstract를 붙이면 추상클래스 
    {
        public abstract void Shout();  // Shout(){}; 본문이 존재하면 안됨. 본문이 존재하지 않기 떄문에 반드시 파생 클래스에서 본문을 정의해야함.
    }

    class Orc2 : Monster2
    {
        public override void Shout()
        {
            Console.WriteLine("Orc Shout!");
        }
    }

    class Skeleton2 : Monster2
    {
        public override void Shout()  // Shout를 만들지 않아도 문법적으로 오류는 없음. 자식 클래스에서 Shout의 구현은 선택이다.
        {
            Console.WriteLine("Skeleton Shout!");
        }
    }

    // 공중에 날아가는 유닛을 만들기 위해 Flyable class 정의. Fly() 구현을 강제한다고 가정. 


    class Program
    {
        static void Main(string[] args)
        {
            Monster m = new Monster();
        }
    }
}
