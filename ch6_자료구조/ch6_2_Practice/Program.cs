using System;

namespace ch6_2_Practice
{
    class Program
    {
        static bool CheckIsArrayEmpty(int[] scores)
        {
            if (scores.Length == 0 || scores == null)
                return true;
            else
                return false;
        }

        static int GetHighestScores(int[] scores)
        {
            if (CheckIsArrayEmpty(scores))
                return 0;

            int highestScore = 0;

            foreach(int score in scores)
            {
                if (score > highestScore)
                {
                    highestScore = score;
                }
            }

            return highestScore;
        }

        static int GetAverageScores(int[] scores)
        {
            if (CheckIsArrayEmpty(scores))
                return 0;

            int Sum = 0;
            foreach(int score in scores)
            {
                Sum += score;
            }

            return Sum / scores.Length;
        }

        // 값이 있는지 찾는 함수
        static int GetIndexOf(int[] scores, int value)
        {
            if (CheckIsArrayEmpty(scores))
                return 0;

            for (int i=0; i < scores.Length; i++)
            {
                if (scores[i] == value)
                    return i;
            }

            return -1;
        }

        static void Sort(int[] scores)
        {
            int temp = 0;
            for(int i=scores.Length-1; i >= 0; i--)
            {
                for (int j=0; j < i; j++)
                {
                    if(Compare(scores[j], scores[j + 1]))  // 둘 중 큰 숫자를 뒤로 보냄
                    {
                        temp = scores[j + 1];
                        scores[j + 1] = scores[j];
                        scores[j] = temp;
                    }
                }
            }
        }

        static bool Compare(int a, int b)
        {
            return a > b;
        }

        static void Main(string[] args)
        {
            int[] scores = new int[5] { 10, 30, 40, 50, 20 };
            int highestScore = GetHighestScores(scores);
            int averageScore = GetAverageScores(scores);
            int idx = GetIndexOf(scores, 30);
            Sort(scores);

            Console.WriteLine($"highestScore : {highestScore}");
            Console.WriteLine($"averageScore : {averageScore}");
            Console.WriteLine($"idx of 30 : {idx}");
            foreach(int score in scores)
            {
                Console.WriteLine(score);
            }


        }
    }
}
