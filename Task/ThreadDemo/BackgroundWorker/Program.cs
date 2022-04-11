using System;

namespace BackgroundWorker
{
    using System.ComponentModel;

    class Program
    {
        static void Main(string[] args)
        {
            new Program().Execute();
            Console.ReadLine();
        }

        private BackgroundWorker worker;

        public void Execute()
        {
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync();
        }

        public void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("Long Running Test");
        }
    }
}
