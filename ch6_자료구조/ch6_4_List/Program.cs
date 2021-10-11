using System;
using System.Collections.Generic;

namespace ch6_4_List
{
    class Program
    {
        static void Main(string[] args)
        {
            // 배열의 아쉬운점 : 사용할 때 크기가 고정
            // 예를들어 배열의 크기를 10으로 줬는데 20개가 필요한 경우 방법이 없음
            // 최대한으로 new int[1000] 으로 크기를 넉넉하게 지정한다면 메모리 낭비
            int[] arr = new int[10];

            // List <- 내부 구현은 동적배열로 되어 있음 
            //         동적 배열이란 데이터가 모자랄 때 사이즈가 큰 배열을 만들고 기존 데이터를 복사한 다음 새로 만든 배열을 연결해주는 개념

            List<int> list = new List<int>();

            for(int i=0; i<5; i++)
                list.Add(i);    // List 끝에 새로운 데이터 넣어줌

            // 삽입, 삭제, 전체삭제
            list.Insert(2, 100);
            bool isRemoved = list.Remove(4);
            list.RemoveAt(1);
            //list.Clear(); // 전체삭제

            for(int i=0; i<list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();

            foreach (int num in list)
            {
                Console.WriteLine(num);
            }
        }
    }
}
