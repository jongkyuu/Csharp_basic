using System;

namespace ch7_9_Nullable
{
    class Monster
    {
        public int Id { get; set; }
    }
    class Program
    {
        static Monster FindMonster(int id)  // id에 해당하는 몬스터를 찾아줌
                                            // class가 참조 타입이라 null을 넣을 수 있음
        {
            // for() 문 돌아서 일치하는 id 있다면
            // return monster;
            return null; // 아무것도 못찾은 경우
        }

        static int Find()
        {
            return 0;
        }
        static void Main(string[] args)
        {
            // Nullable -> Null + able
            Monster monster = FindMonster(101);
            if(monster != null)  // monster가 null인지 판단해서 몬스터가 있는지 판단
            {

            }

            int? number = null;  // int에 ? 붙이면 null도 될수 있다는 의미
            number = 3;
            //int a = number;  // nullable 형식인 int? 와 int를 변환할 수 없다는 에러 나옴
            int a = number.Value;  // number.Value 하면 문제 해결
            Console.WriteLine(a);

            int? number2 = null;
            //int b = number2.Value;  // null값이라 Error 발생

            //null인지 아닌지 체크해야함
            if(number2 != null)
            {
                Console.WriteLine(number2);
            }
            if (number2.HasValue)
            {
                Console.WriteLine(number2);
            }

            // ??
            int c = number2 ?? 0; // number2가 null이 아니라면 nuber2의 값을, null이라면 0을 반환
            // int c = number2 != null ? number2.Value : 0; 삼항 연산자를 사용한것과 비슷
            Console.WriteLine(c);

            Monster monster2 = null;
            int? id = monster2?.Id;  // monster가 null이 아니라면 Id를 뽑아주고, null이라면 null을 넣어줌
            // 아래 코드와 의미가 같음
            if(monster == null)
            {
                id = null;
            }
            else
            {
                id = monster2.Id;
            }
        }
    }
}
