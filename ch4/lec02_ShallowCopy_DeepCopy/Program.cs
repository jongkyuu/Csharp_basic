using System;

namespace lec02_ShallowCopy_DeepCopy
{
    // Class는 침조(ShallowCopy)
    class Knight
    {
        public int hp;
        public int attack;

        public void Move()
        {
            Console.WriteLine("Knight Move");
        }

        // DeepCopy 함수 Clone() 생성
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

    // struct는 복사(DeepCopy)
    struct Mage
    {
        public int hp;
        public int attack;
    }

    class Program
    {
        static void KillMage(Mage mage)
        {
            mage.hp = 0;
        }
        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }


        static void Main(string[] args)
        {

            Mage mage;
            mage.hp = 100;
            mage.attack = 50;
            KillMage(mage);   // struct의 경우 복사로 값을 넘기기 때문에 원본에는 영향을 미치지 않음

            Mage mage2 = mage;
            mage2.hp = 0;   // mage2.hp = 0 으로 줘도 mage.hp 는 100을 유지함. 별도의 마법사라고 볼 수 있다

            Knight knight = new Knight();  // class의 경우 참조로 값을 넘기기 때문에 원본에 그대로 영향을 줌
            knight.hp = 100;
            knight.attack = 10;

            knight.Move();
            knight.Attack();
            knight.Info();

            //KillKnight(knight);

            Knight knight2 = knight;  // knight와 knight2 는 같은 기사를 의미함.
            //knight2.hp = 0;

            //KillKnight(knight);     // knight.hp = 0 을 주면 knight2.hp 도 0임

            //ight knight3 = new Knight();  // new로 생성하면 서로 독립된 개체임
            Knight knight3 = knight.Clone();   // DeepCopy 함수 추가
            knight3.hp = knight.hp;
            knight3.attack = knight.attack;

        }
    }
}
