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

    // 공중에 날아가는 유닛을 만들기 위해 Flyable class 정의하고 Flyable의 파생클래스는 Fly() 구현을 강제한다고 가정. 

    abstract class Flyable
    {
        public abstract void Fly();
    }

    // class FlyableOrc : Orc2, Flyable  // C#에서는 다중상속을 지원하지 않아서 기본클래스를 두개 이상 상속할 수 없음(죽음의 다이아몬드 문제). C++에서는 가능한 문법
    // {    }

    interface IFlyable   // 인터페이스는 선언(Declaration)은 있고, 정의(Definition)은 없다.
                         // 인터페이스는 접근 제한 한정자를 사용할 수 없고 모든 멤버는 public으로 선언됩니다.
                         // 인터페이스를 상속받은 자식 클래스는 인터페이스에 있는 모든 멤버를 구현해야 하며 public으로 구현해야 합니다.
    {
        void Fly();
    }

    class FlyableOrc : Orc2, IFlyable  // 클래스는 하나의 base 클래스와 여러개의 interface를 가질 수 있다
    {
        public void Fly()
        {
            Console.WriteLine("Orc Fly!");
        }
    }

    class FlyableSkeleton : Skeleton2, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Skeleton Fly!");
        }
    }

    class PushToFlyTightCoupling
    {
        public void PushToFly(FlyableOrc flyable)  // 강한결함. 강한 결합은 코드의 유연성과 재사용성을 떨어뜨림.
        {
            flyable.Fly();
        }
    }

    class PushToFlyLooseCoupling
    {
        public void PushToFly(IFlyable flyable)  // 느슨한 결함. 클래스 의존성을 줄여줌.
        {
            flyable.Fly();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Monster m = new Monster();

            IFlyable flyableOrc = new FlyableOrc();  // FlyableOrc()로 생성한 객체도 IFlyable 로 선언된 변수에 저장 가능
            
            // 강한결합, 느슨한 결합 예제
            FlyableOrc flyableOrc2 = new FlyableOrc();
            FlyableSkeleton flyableSkeleton2 = new FlyableSkeleton();

            // 강한 결합
            PushToFlyTightCoupling pushToFlyTightCoupling = new PushToFlyTightCoupling();  // 날기 위해 밀어주는 기능이 구현된 클래스라고 가정.
            pushToFlyTightCoupling.PushToFly(flyableOrc2); // PushToFlyTightCoupling 클래스는 DoFly를 할때 항상 FlyableOrc가 와야하기 때문에 클래스간 결합이 강하다
            //pushToFlyTightCoupling.PushToFly(flyableSkeleton2); // 왼쪽 코드는 Error발생. 따라서 FlyableSkeleton을 날게 하려면 PushToFlyTightCoupling 클래스도 바꿔줘야 하는 단점이 있음

            // 느슨한 결합
            PushToFlyLooseCoupling pushToFlyLooseCoupling = new PushToFlyLooseCoupling();
            pushToFlyLooseCoupling.PushToFly(flyableOrc2);
            pushToFlyLooseCoupling.PushToFly(flyableSkeleton2);  // 인터페이스를 통한 느슨한 결합을 하면 IFlyable을 상속받은 어떤 클래스가 와도 PushToFlyLooseCoupling 클래스의 변경없이 구현 가능하다.

        }

    }
}
