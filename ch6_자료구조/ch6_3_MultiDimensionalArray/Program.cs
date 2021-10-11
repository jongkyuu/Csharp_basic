using System;

namespace ch6_3_MultiDimensionalArray
{
    class Map
    {
        // 0은 갈 수 있음, 1은 갈수 없음
        int[,] tiles = new int[,]{
            {1,1,1,1,1},
            {1,0,0,0,1},
            {1,0,0,0,1},
            {1,0,0,0,1},
            {1,1,1,1,1}
            };

        public void Render()
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    if (tiles[y, x] == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\u25cf");
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = defaultColor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1차원 배열
            int[] scores = new int[5] { 1, 2, 3, 4, 5 };

            // 2차원 배열
            int[,] arr = new int[2, 3] { { 1, 2, 3} , { 2, 3, 4 } };
            int[,] arr2 = new int[,] { { 1, 2, 3} , { 2, 3, 4 } };
            int[,] arr3 = { { 1, 2, 3} , { 2, 3, 4 } };

            arr[0, 0] = 1;
            arr[1, 0] = 1;

            // 가변배열
            int[][] a = new int[2][];
            a[0] = new int[3];
            a[1] = new int[5];

            a[0][0] = 1;

            Map map = new Map();
            map.Render();
        }
    }
}
