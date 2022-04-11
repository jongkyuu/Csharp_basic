using System;
using System.Threading;

namespace ch7_4_1_DelegatePractice
{
    class Area
    {
        public delegate void ClickDelegate();

        public ClickDelegate MyClick;

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
            area.MyClick = Area_Click;
            Console.WriteLine("MyArea를 클릭합니다");
            area.MouseClick();
            area.MyClick(); // 델리게이트는 이렇게 직접 호출할 수 있어서 문제가 될 수 있음 

        }

        static void Area_Click()
        {
            Console.WriteLine("MyArea 클릭");
        }
    }
}
