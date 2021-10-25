using System;
using System.Threading;

namespace ThreadClass
{
    class Helper
    {
        // 다른 클레스의 메서드를 쓰레드에 호출하기 위해서는
        // 해당 클래스의 객체를 생성한 후(혹은 외부로부터 전달받은 후)
        // 그 객체의 메서드를 델리게이트로 Thread에 전달하면 된다
        public void Run()
        {
            Console.WriteLine("Helper.Run");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new Program().DoTest();
        }

        void DoTest()
        {
            // 새로운 쓰레드에서 run() 실행
            // Run 메서드를 입력받아 ThreadStart 델리게이트 타입 객체를 생성한 후 Thread  클래스 생성자에 전달
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            // 메인 쓰레드에서 Run() 실행
            Run();

            // 컴파일러가 Run() 메서드의 함수 프로토타입으로부터
            // ThreadStart 델리게이트 객체를 추론하여 생성함
            Thread t2 = new Thread(Run);
            t2.Start();

            // 익명메서드를 사용하여 쓰레드 생성
            Thread t3 = new Thread(delegate()
            {
                Run();
            });
            t3.Start();

            // 람다식을 사용하여 쓰레드 생성
            Thread t4 = new Thread(() => Run());
            t4.Start();

            // 간략한 표현
            new Thread(() => Run()).Start();

            // Helper 클래스의 Run메서드 호출
            Helper helper = new Helper();
            Thread t5 = new Thread(helper.Run);
            t5.Start();
        }

        void Run()
        {
            Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId} : Begin");
            Thread.Sleep(1000);
            Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId} : End");
        }
    }
}
