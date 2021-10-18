using System;

namespace ch7_1_Generic
{
    // 우리만의 자료구조를 만든다고 가정하면
    // 데이터 형식을 여러가지 지원해줘야 하기 떄문에 여러 형식의 List를 만들어 줘야함
    class MyIntList
    {
        int[] arr = new int[10];
    }

    class MyFlostList
    {
        float[] arr = new float[10];
    }

    class MonsterList
    {
        Monster[] arr = new Monster[10];
    }

    class Monster
    {

    }

    // T는 Type, Template의 약자
    class MyList<T>
    {
        // obejct 타입으로 선언할 수 있지만 박싱, 언박싱을 거쳐야 하기 떄문에 성능상 좋지 않음
        // object[] arr = new object[10];
        T[] arr = new T[10];

        public T GetItem(int i)
        {
            return arr[i];
        }
    }

    class MyDictionary<T, K> // 인자가 두개라면 이런식으로 표현할 수 있다
    {
        //...
    }

    // Generic Type에 조건을 추가할 수 있다
    class MyListStruct<T> where T : struct   // : struct일때 T는 값 형식이어야 함.
                                             // : class는 참조 형식,
                                             // : new()는 어떠한 인자도 받지 않는 기본 생성자가 있어야 함.
                                             // : Monster는 Monster나 Monster를 상속받은 클래스가 들어가야 함
    {
        T[] arr = new T[10];

        public T GetItem(int i)
        {
            return arr[i];
        }
    }

    class Program
    {
        // 하나의 함수로 여러 타입을 사용할 수 있음
        static void Test<T>(T input)
        {

        }

        static void Main(string[] args)
        {
            // object를 사용하는 방법.
            // 어떤 타입이든 다 소화가 가능함
            object obj = 3;
            object obj2 = "Hello";

            int num = (int)obj;
            string str = (string)obj2;

            // var는 컴파일러가 어떤 타입인지 알아서 변환해줌
            // object는 int, string의 부모 클래스임. object를 상속 받아서 구현
            // int는 스택에 들어가는 정보. 복사 타입의 변수
            // object는 참조 타입. 힙에 메모리를 할당 해서 거기 숫자를 저장한 다음 꺼내올 때는 힙에서 숫자를 꺼내서 스택에 저장 (박싱, 언박싱)
            // 따라서 전부 object 타입으로 선언하는 것은 성능상에 무리가 있디

            MyList<int> myIntList = new MyList<int>();
            MyList<float> myFloatList = new MyList<float>();
            MyList<Monster> myMonsterList = new MyList<Monster>();

            int item = myIntList.GetItem(0);

            Test<int>(3);
            Test<float>(3.0f);
        }
    }
}
