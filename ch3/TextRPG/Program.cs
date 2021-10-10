using System;

namespace TextRPG
{

    class Program
    {
        static void ShowJobs()
        {
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
        }
        static void Main(string[] args)
        {
            bool choice_flag = false;
            while (choice_flag != true)
            {
                ShowJobs();
                string number = Console.ReadLine();
                if (number == "1" || number == "2" || number == "3")
                {
                    choice_flag = true;
                }
                
            }
        }
    }
}
