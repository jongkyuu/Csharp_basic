using System;

namespace ch6_1_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열
            int[] scores = new int[5];  // new int로 숫자를 동적으로 할당. 배열은 참조 타입
            scores[0] = 10;
            scores[1] = 20;
            scores[2] = 30;
            scores[3] = 40;
            scores[4] = 50;

            // 아래 배열 선언은 모두 같은 기능을 함
            int[] scores_2 = new int[5] { 10, 20, 30, 40, 50 };

            int[] scores_3 = new int[] { 10, 20, 30, 40, 50 };

            int[] scores_4 = { 10, 20, 30, 40, 50 };


            // 참조 타입 참고할 내용
            int[] scores_ref = scores;
            scores_ref[0] = 100;


            for (int i=0; i<scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
        }
    }
}
