using System;

namespace lec03_Stack_and_Heap
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


            // 스택은 굉장히 불안정하고 임시적으로 사용하는 메모리
            // 함수를 호출할때 임시 값을 넣었다가 함수가 종료되면 더이상 사용하지 않음
            // 이런 상황에서 사용하는게 스택. 함수를 실행하기 위한 메모장 같은 존재라고 생각하면 됨
            // 함수 안에서 선언된 변수들은 무조건 스택 영역에 들어간다고 간단하게 생각하면 됨.

            // 복사되는 타입과 참조되는 타입을 살펴보면
            // 복사되는 타입은 메모리 안에 자신의 본체가 들어 있음. Mage 같은 경우 attack, hp (8바이트) 메모리 사이즈만큼 할당을 해서 본체가 들어감
            
            // 참조되는 타입은 메모리 안에 주소가 들어감
            // 64bit 컴퓨터에서는 64bit(8바이트), 
            // 주소 안에는 실제 본체가 있는 메모리의 주소를 나타냄
            // 참조 타입의 본체는 Heap 영역에 들어감
            // Heap 영역은 동적으로 할당하는 거
            // 프로그램이 실행되면서 new knight() 했을때 실시간으로 메모리 할당을 요구하는데
            // 이때 Heap 메모리에 할당함
            // 참조 타입은 steack에 있는 주소가 heap 메모리 영역의 본체를 가리킴

            // Stack 영역은 함수가 실행되는 순간부터 종료되는 구간까지 함수가 어느정도의 스택 공간을 사용하는지 계속 추적함
            // stack 영역은 신경쓸 필요가 없다. 함수가 호출되고 종료될때 알아서 늘었다 줄었다 잘 관리가 됨
            // Heap 영역은 메모리 할당을 하고 딱히 어떤 행동을 안하면 계속 메모리가 남아있음
            // c++은 프로그래머가 메모리 해제까지 요구를 해야함
            // c# 은 가비지컬렉터가 알아서 관리해줘서 본체를 가키는 주소가 없을때 메모리를 해제해 줌

        }
    }
}

