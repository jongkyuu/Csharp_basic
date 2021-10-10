using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch5_TextRPG2
{
    public enum MonsterType
    {
        None,
        Slime,
        Orc,
        Skeleton
    }

    class Monster : Creature
    {
        protected MonsterType type = MonsterType.None;
        protected Monster(MonsterType type) : base(CreaturType.Monster)
        {
            this.type = type;
        }

        public MonsterType GetMonsterType() { return type; }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo(10, 5);
        }
    }
    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo(20, 15);
        }
    }

    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton)
        {
            SetInfo(15, 20);
        }
    }
}
