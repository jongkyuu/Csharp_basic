using System;

namespace ch7_3_Property
{
    class Program
    {
        // 객체지향 -> 은닉성
        // 은닉성이란? 불필요한 정보를 외부에 노출하지 않음
        class Knight
        {
            // public int hp;  
            // hp를 public으로 열어두면 큰 규모의 프로젝트에서는 문제가 있음
            // 큰 규모의 프로젝트에서는 다른 사람이 만든 Knight 클래스를 가져다가 사용하는 경우가 발생함

            // 그래서 hp를 protected나 private로 선언해서 외부에서 hp에 바로 접근할 수 없도록 한 다음
            // 필요하다면 함수를 통해 접근하도록 함
            protected int hp;
            public int GetHp() { return this.hp; }
            public void SetHp(int hp) { this.hp = hp; }   // Setter, Set함수 라고 부름

            // 변수를 숨기고 특정 함수로만 접근 가능하게 하면 장점이 많다
            // 예를들면 특정 조건에서만 hp를 수정할 수 있다고 하면 SetHP에 조건문을 추가하면 된다.
            // 또 유지보수 할때, hp 멤버에 언제 접근했는지 일일이 다 알기 힘든데, 함수를 통해 접근하도록 하면 Set함수에 중단점을 걸어 호출 스택을 확인 할 수 있어 유용하다

            // 그런데 변수가 많아지면 Getter, Setter가 많아지게 된다.
            // C++은 Getter, Setter를 다 구현해줘야 하지만 C#에서는 프로퍼티를 통해 좀 더 간단하게 구현할 수 있다
            protected int mp;
            public int Mp
            {
                get { return mp; }
                set { mp = value; }   // default로 value를 사용.
            }

            // 값을 셋팅하지 못하고 읽어오는 용도로만 사용하려면 get만 정의하면 된다.
            protected string job = "Knight";
            public string Job
            {
                get { return job; }
            }

            // get은 외부에 노출해서 사용할 수 있도록 하고, set은 내부에서만 사용할 수 있도록 막고싶은 경우
            protected int shield = 5;
            public int Shield
            {
                get { return shield; }
                private set { shield = value; }
            }

            void LevelUp()
            {
                shield += 10;  // 내부에서 접근 가능하기 떄문에 shield 값을 올려줄 수 있음 
            }

            // 자동 구현 프로퍼티
            // protected로 선언된 필드(멤버변수)를 추가할 필요 없음 
            public int Resistance { get; set; } = 10; // C# 7.0부터는 =100 처럼 초기화 문법을 넣을 수 있음 

            // 컴파일러가 내부적으로 private 멤버 변수를 자동으로 생성하고 Get함수와 Set함수를 구현해줌
            // 자동구현 프로퍼티는 아래 3줄의 코드를 축약한 것이다.
            private int resistance;
            public int GetResistance() { return resistance; }
            public void SetResistance(int value) { resistance = value; }

        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();

            // hp에 접근하면 안되지만 실수로 hp에 접근해서 값을 수정하는 경우가 생길 수 있고,
            // Knight 클래스를 여러군데서 사용한다면 어디서 hp의 값을 바꾼건지 굉장히 찾기가 어려워짐
            //knight.hp = 100;  
            // Set함수 사용
            int hp = knight.GetHp();
            knight.SetHp(100);

            // 프로퍼티 사용
            // 사용성은 편리하지만 내부적으로 은닉성도 지킬 수 있는 문법
            knight.Mp = 100;  // value에 100이 들어감
            int mp = knight.Mp;
            string job = knight.Job;  // Job은 읽기만 가능
            //knight.Shield = 10; // private set을 구현했기 때문에 외부에서 접근이 안됨.
        }
    }
}
