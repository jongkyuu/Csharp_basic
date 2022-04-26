using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Task t = TaskTest();
            Task<int> t2 = TaskTestDB();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Do Something Before TaskTest");
            }

            //await t;
            int UID = await t2;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Do Something After TaskTest");
            }

            Console.WriteLine($"UID : {UID}");
            Console.ReadLine();
        }

        static async Task TaskTest()
        {
            await Task.Delay(5000);
            Console.WriteLine("TaskTest Done");
        }

        static async Task<int> TaskTestDB()
        {
            //await Task.Delay(5000);
            //Console.WriteLine("TaskTestDB Done");
            //int UID = 100;

            int UID = await GetUID();
            Console.WriteLine("TaskTestDB Done");

            return UID;
        }

        static async Task<int> TaskTestDB2()
        {
            int UID = await Task.Run(() => GetUID2());
            Console.WriteLine("TaskTestDB Done");

            return UID;
        }

        static async Task<int> GetUID()
        {
            await Task.Delay(5000);
            // DB에서 UID 가져오는 작업
            int UID = 100;
            return UID;
        }

        static int GetUID2()
        {
            Thread.Sleep(5000);
            // DB에서 UID 가져오는 작업
            int UID = 100;
            return UID;
        }
    }
}
