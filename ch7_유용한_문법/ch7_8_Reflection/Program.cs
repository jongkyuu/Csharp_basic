using System;
using System.Reflection;

namespace ch7_8_Reflection
{
    class Monster
    {
        // Attribute를 이용하면 런타임에서 참고할 수 있는 힌트를 남길 수 있다
        [Importanct("Very Important")]   // 컴퓨터가 런타임에 체크할 수 있는 주석
        public int hp;
        protected int attack;
        private float speed;

        void Attack() { }
    }

    class Importanct : Attribute
    {
        private string message;

        public Importanct(string message)
        {
            this.message = message;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Reflection은 일상적으로 사용되지는 않지만 개념적으로 중요함
            // Reflection : X-Ray를 찍는 것과 같다
            //              Reflection을 사용하면 클래스가 가지고 있는 모든 정보들을 런타임에 다 뜯어보고 분석할 수 있다
            // 사용 예 : 유니티에서 프로그램 실행 중에 스크립트에 어떤 멤버가 있는지 체크해 자동으로 UI를 열어주는 등의 기능을 리플렉션으로 쉽게 만들 수 있다.
            //           언리얼은 C++이라 리플렉션이 없으므로 이를 힘들게 구현한다

            Monster monster = new Monster();
            Type type = monster.GetType();  // 모든 객체는 object 객체에서 파생되었기 때문에 GetType을 정의해 주지 않아도 사용 가능

            // 클래스의 모든 정보들을 빼내 올 수 있다
            var fields = type.GetFields(BindingFlags.Public  // 어떤 정보를 빼올지 입력. Flag로 입력한다
                            | BindingFlags.NonPublic
                            | BindingFlags.Static
                            | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";

                var attributes = field.GetCustomAttributes();
                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");

            }
        }
    }
}
