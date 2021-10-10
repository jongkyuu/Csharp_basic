using System;

namespace ch5_TextRPG2  // 같은 네임스페이스에 있으면 같은 파일에 있는 것처럼 class를 사용할 수 있음
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (true)
            {
                game.Process();
            }
        }
    }
}
