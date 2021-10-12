using System;
using System.Collections.Generic;

namespace ch6_5_Dict
{
    class Monster
    {
        public int id;
        public Monster(int id)
        {
            this.id = id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // ID 식별자
            // 10 103 (예를들어 10은 공격, 103은 몬스터ID  이런식으로 클라와 서버가 통신을 함)
            // List로 관리하고 있으면 이걸 어떻게 찾는가가 문제
            // 몬스터가 100만마리가 있다면 100만개를 돌면서 103번인지 체크하는 방법밖에 없음

            // 이런 상황에서 Dictionary가 유용
            // Key를 알면 Value를 굉장히 빠르게 찾을 수 있음 (Value로 키를 빠르게 찾는건 안됨)
            // Dictionary는 Hashtable 이란 기법 사용
            // 아주 큰 박스에 공이 1만개가 들어있고 1~1만까지의 번호가 써져 있다고 가정. 1만개 중에 원하는 숫자 찾기가 힘들다
            // 이걸 10개씩 박스 1천개에 쪼개 놓는다면 훨씬 찾기가 쉬워진다. 7777번 공은 777번째 상자에 들어있음 
            // 박스를 많이 준비해놓아야 하므로 메모리 손해를 볼 수 있음. 메모리를 내주고 성능을 취함


            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();
            dic.Add(1, new Monster(1));   // 이런식으로 Key, Value를 추가하거나
            dic[5] = new Monster(5);      // 이런식으로 추가함

            Dictionary<int, Monster> dic2 = new Dictionary<int, Monster>(); 
            for(int i=0; i<10000; i++)
            {
                dic2.Add(i, new Monster(i));
            }

            Monster mon_5000 = dic2[5000];   // 존재하지 않는 Key를 넣으면 Exception 발생

            Monster mon_20000;
            bool found = dic2.TryGetValue(7777, out mon_20000);

            dic.Remove(5);
            dic.Clear();
        }
    }
}
