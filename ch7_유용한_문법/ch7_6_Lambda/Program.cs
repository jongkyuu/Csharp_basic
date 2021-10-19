using System;
using System.Collections.Generic;

namespace ch7_6_Lambda
{
    enum ItemType
    {
        Weapon,
        Armor,
        Ring
    }

    enum Rarity // 희귀성
    {
        Normal,
        Uncommon,
        Rare
    }

    class Item  // 아이템 종류와 희귀도를 가진 클래스
    {
        public ItemType ItemType;
        public Rarity Rarity;
    }
    class Program
    {
        static List<Item> _items = new List<Item>();  // 가상의 인벤토리, main에서 사용하기 위해 static 선언

        // 어떤 아이템을 가지고 있는지 인벤토리를 조회하는 경우

        static Item FindWeapon() // 인벤토리에 Weapon이 있는지 체크해서 있으면 반환, 여러개면 처음 찾은걸 반환
        {
            foreach (Item item in _items)
            {
                if(item.ItemType == ItemType.Weapon)
                {
                    return item;
                }
            }
            return null;  // 못찾으면 null 반환
        }

        static Item FindRareItem() // 인벤토리에 Rare Item이 있는지 체크해서 있으면 반환, 여러개면 처음 찾은걸 반환
        {
            foreach (Item item in _items)
            {
                if (item.Rarity == Rarity.Rare)
                {
                    return item;
                }
            }
            return null;  // 못찾으면 null 반환
        }

        // 이런식으로 필요에 따라 함수를 늘리는 건 무식한 방식이다
        // 경우에 따라 인벤토리 서칭하는 부분의 코드가 길어질 수 있는데 그 긴 코드를 위처럼 복붙하면 비효율적이다
        // 델리게이트를 활용하면 비효율적인 부분을 해결할 수 있다

        delegate bool ItemSelector(Item item);  

        static Item FindItem(ItemSelector selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))  // selector 의 조건을 item이 무사히 통과하면 item 반환
                    return item;
            }
            return null;  // 못찾으면 null 반환
        }
        // 위처럼 구현하면 인자로 들어가는 ItemSelector에 넣어줄 함수는 만들어 줘야 한다
        // 예를들어 Weapon을 찾기 위해 IsWeapon이라는 함수를 만들고 이걸 FindItem의 인자로 넘겨준다
        static bool IsWeapon(Item item)
        {
            return item.ItemType == ItemType.Weapon;
        }

        // 델리게이트 타입의 타입에도 제너릭 형식을 사용할 수 있음. 다른곳에서도 활용할 수 있는 공용 델리게이트를 만듬
        delegate Return MyFunc<T, Return>(T item); // 일반적인 경우에도 사용하기 위해 이름을 MyFunc으로 지정
                                                   // 입력 형식이 하나, 반환 형식이 하나 있는 타입의 델리게이트는 모두 MyFunc을 이용해서 넘겨줄 수 있음

        // 하지만 위와 같은 공용 델리게이트의 경우 인자를 하나밖에 못받는다
        // 이에 대한 해답은 인자 갯수만큼 델리게이트를 준비해놓으면 된다
        delegate Return MyFunc<Return>(); // 반환 형식은 있고 입력 형식은 안넘겨주는 타입
        delegate Return MyFunc<T1, T2, Return>(T1 t1, T2 t2); // 입력은 두개 받고 반환은 하나만 하는 버전

        // C#에서는 위와 같은 델리게이트를 다 만들어 둠
        // Func 델리게이트를 사용
        

        static Item FindItem2(MyFunc<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if (selector(item))  // selector 의 조건을 item이 무사히 통과하면 item 반환
                    return item;
            }
            return null;  // 못찾으면 null 반환
        }


        static void Main(string[] args)
        {
            _items.Add(new Item() { ItemType = ItemType.Weapon, Rarity = Rarity.Normal });
            _items.Add(new Item() { ItemType = ItemType.Armor, Rarity = Rarity.Uncommon });
            _items.Add(new Item() { ItemType = ItemType.Ring, Rarity = Rarity.Rare });

            //Item item = FindWeapon();

            Item item = FindItem(IsWeapon);  // 이렇게 실행은 잘 되지만 조건을 하나 넣을때마다 함수를 하나씩 만드는게 부담스러울 수 있음
                                             // 조건이 IsArmor, IsRing... 등 다 포함해서 20개라면 IsWeapon같은 함수를 여러개 만들어줘야함
                                             // 결국 FindWeapon, FindRing 등의 함수를 각각 만드는 중복작업을 피하기 위해 FindItem을 만들었는데
                                             // ItemSelector 부분에서 다시 코드가 늘어나기 떄문에 아쉬운 부분이 있음
                                             // 한번만 사용할 함수라면 일회용으로 사용하고 버리는 문법이 람다(Lambda) 이다

            // Anonymous Function(무명함수, 익명함수)
            Item item2 = FindItem(delegate (Item item) { return item.ItemType == ItemType.Weapon; });
            // Weapon을 찾는 부분을 다른곳에서도 사용한다면 또 delegate로 만들어 줘야하는 단점이 있지만
            // 어쩌다가 한번 사용할 일회성 함수라면 이렇게 선언하는게 좋음

            // Lambda : 일회용 함수를 만드는데 사용하는 문법  ((입력값) => {반환값})
            // 람다는 무명함수를 편하게 만드는 방법
            Item item3 = FindItem((Item item) => { return item.ItemType == ItemType.Weapon; });

            // 람다식을 꼭 일회용으로 사용하기만 하는것은 아니다.
            // 델리게이트 객체를 만들떄 람다식을 사용하면 재사용 가능
            ItemSelector selector = new ItemSelector((Item item) => { return item.ItemType == ItemType.Weapon; });
            Item item3_1 = FindItem(selector);

            // ItemSelector 대신 일반적인 경우에도 사용할 수 있는 MyFunc를 사용
            MyFunc<Item, bool> selector2 = new MyFunc<Item, bool>((Item item) => { return item.ItemType == ItemType.Weapon; });
            // 아래처럼 new 부분 없애고 줄일 수 있음 
            MyFunc<Item, bool> selector3 = (Item item) => { return item.ItemType == ItemType.Weapon; };

            // Func를 사용
            Func<Item, bool> selector4 = (Item item) => { return item.ItemType == ItemType.Weapon; };

            // 만약 리턴이 없는 델리게이트라면 Action을 사용
            // Action<Item>

            // 델리게이트를 직접 선언하지 않아도 이미 공용으로 사용할 수 있도록 만들어진 델리게이트가 존재
            // 반환 타입이 있는 경우 Func
            // 반환 타입이 없는 경우 Action 사용

        }
    }
}
