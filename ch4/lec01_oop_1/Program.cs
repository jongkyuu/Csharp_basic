using System;

namespace lec01_oop_1
{
    class Knight
    {
        public int hp;
        public int attack;

        public void Move()
        {
            Console.WriteLine("Knight Move");
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
            Knight knight = new Knight();
                                            // = new Knight(); 부분 없으면 할당되지 않은 knight 지역변수를 사용했다고 에러 메세지 나옴
                                            // = null; 을 넣어주면 존재하지 않는 객체로 선언한 것인데, 존재하지 않는 객체에 접근하려고 하면 crash가 남. 
                                            // 게임에서 crash 나는것의 80%는 null crash라고 함
            knight.hp = 100;
            knight.attack = 10;

            knight.Move();
            knight.Attack();
            knight.Info();
        }
    }
}
