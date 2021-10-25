using System;
using System.Diagnostics;

// https://infodbbase.tistory.com/91?category=552284
namespace GetProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            // 찾을 특정 프로세스를 지정
            Process[] processList = Process.GetProcessesByName("notepad");
            while (processList.Length < 1)
            {
                // 특정 프로세스가 동작할때까지 찾음
                processList = Process.GetProcessesByName("notepad");
                Console.WriteLine("Process Searching...");
            }
            Console.WriteLine("Process Find!");
            Console.ReadLine();
        }
    }
}
