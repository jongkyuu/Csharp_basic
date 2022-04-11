using System;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        void Start()
        {
            Task.Factory.StartNew(new Action<object>(Run), null);
            Task.Factory.StartNew(new Action<object>(Run), "1st");
            Task.Factory.StartNew(Run, "2nd");
            Task.Factory.StartNew(() => { Run("3nd"); });

            Console.ReadLine();
        }


        void Run(object data)
        {
            Console.WriteLine(data == null ? "NULL" : data);
        }

    }
}
