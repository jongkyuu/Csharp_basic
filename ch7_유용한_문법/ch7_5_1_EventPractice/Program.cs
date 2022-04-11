using System;
using System.Threading;

namespace ch7_5_1_EventPractice
{
    class Area
    {
        public delegate void ClickDelegate();

        public event ClickDelegate MyClick;

        public Area()
        {

        }

        public void MouseClick()
        {
            Thread.Sleep(5000);
            AreaClicked();
        }

        void AreaClicked()
        {
            if (MyClick != null)
                MyClick();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Area area = new Area();
            area.MyClick += Area_Click;   // = (할당연산자) 사용 불가
            Console.WriteLine("MyArea를 클릭합니다");
            area.MouseClick();
            //area.MyClick(); // 이벤트를 선언한 클래스 외부에서는 이벤트 직접 호출 불가 
        }

        static void Area_Click()
        {
            Console.WriteLine("MyArea 클릭");
        }
    }
}
