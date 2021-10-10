using System;

namespace lec04_Constructor
{
    class Knight
    {
        public int hp;
        public int attack;

        public Knight()  // 클래스 이름과 같아야함. 반환 타입이 없어야함. 
        {
            hp = 100;
            attack = 10;
            Console.WriteLine("생성자 호출");
        }

        public Knight(int hp) : this() // this() 는 자신의 빈 생성자를 호출시켜 달라는 의미. 먼저 매개변수가 없는 생성자 호출 후 int hp 생성자 호출
        {
            this.hp = hp;   // this 키워드를 사용하면 매개변수로 넘겨받은 hp가 아니라 자신의 hp를 의미
            Console.WriteLine("int 생성자 호출");
        }

        public Knight(int hp, int attack) : this(hp)
        {
            //this.hp = hp;
            this.attack = attack;
            Console.WriteLine("int, int 생성자 호출");
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
            Knight knight = new Knight(80, 15);  // Knight를 new로 생성함과 동시에 값을 전달하는 방법이 생성자



           
        }
    }
}

