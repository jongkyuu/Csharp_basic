using System;

namespace lec05_Static
{
    class Knight
    {
        // 필드, 필드는 Knight 인스턴스 객체마다 다를 수 있다
        public int hp;
        public int attack;
        public int id; // Knight 객체 생성할때 마다 id값이 1씩 증가하도록 만들고 싶음.

        static public int counter = 1; // 오직 1개만 존재. 직접 Knight 클래스에서 호출.

        static public void Test()  // static은 메소드에 붙을 수도 있는데 의미는 같음. Knight 클래스에 종속되기 때문에 유일성이 보장됨
        {
            // static 함수 내부에서는 인스턴스 객체 멤버를 참조해서는 안된다.
            // static이 없는 필드는 인스턴스 객체에 종속적인 필드가 된다.
            // static을 붙였다고 해서 일반 인스턴스에 접근하지 못하는 것은 아니다.
        }

        public static Knight CreateKnight()
        {
            Knight knight = new Knight();  // 새로운 Knight 객체를 생성
            knight.hp = 100;               // hp나 attack에 접근하기 위해서 새로운 Knight 객체를 생성
            knight.attack = 1;
            return knight;
        }

        public Knight()  // 생성자. 클래스 이름과 같아야함. 반환 타입이 없어야함. 
        {
            id = counter;
            counter++;
            this.hp = 100;
            this.attack = 10;
            Console.WriteLine("생성자 호출");
        }
        public Knight(int hp, int attack)  // 생성자. 클래스 이름과 같아야함. 반환 타입이 없어야함. 
        {
            id = counter;
            counter++;
            this.hp = hp;
            this.attack = attack;
            Console.WriteLine("생성자 호출");
        }

        public void Move()
        {
            Console.WriteLine("Knight Move");
        }

        public Knight Clone()
        {
            Knight knight = new Knight();  // new로 생성하면 서로 독립된 개체임
            knight.hp = hp;
            knight.attack = attack;
            return knight;
        }

        public void Attack()
        {
            Console.WriteLine("Knight Attack");
        }

        public void Info()
        {
            Console.WriteLine($"HP : {hp}, ATTACK : {attack}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight(80, 15);

            // static으로 선언된 케이스의 경우에는 코드가 Knight 클래스에 종속적이라 클래스.메서드 형식으로 호출

            Knight knight1 = Knight.CreateKnight(); // static, 클래스를 통해 접근
            knight1.Move();   // 일반, 인스턴스 객체를 통해서 점근

            Console.WriteLine();  // static type임을 예상할 수 있음

            Random rand = new Random();
            rand.Next();  // rand는 static이 아님을 유추할 수 있음
        }
    }
}

