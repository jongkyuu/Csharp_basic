using System;

namespace lec06_inheritance
{

    //OOP ( 은닉성 / 상속성 / 다형성 )

    class Player  // 상속을 해주는 상위 계층을 부모 클래스, 기반 클래스라고 함 
    {
        //필드
        static public int counter = 1; // 오직 1개만 존재. 
        public int hp;
        public int attack;
        public int id;
        public void Move()
        {
            Console.WriteLine("Player Move");
        }

        public void Attack()
        {
            Console.WriteLine("Player Attack");
        }
    }

    class Mage : Player  // 상속을 받는 계층을 자식 클래스, 파생 클래스 라고 함
    {

    }

    class Archer : Player
    {

    }

    class Knight : Player 
    {
        public void Stun()
        {

        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            Knight knight = new Knight();
            knight.Move();   // 속성, 기능 모두 자식이 이어받아서 사용할 수 있음.
                             // 공통적인 부분은 부모 클래스에 몰아 넣고 knight 만 가지고 있는 몇가지만 따로 정의해주면 됨.
                             // 예를 들면 기사의 stun 스킬.
        }
    }
}

