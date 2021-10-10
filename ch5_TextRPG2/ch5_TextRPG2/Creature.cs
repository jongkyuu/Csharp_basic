using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch5_TextRPG2
{
    public enum CreaturType
    {
        None, 
        Player,
        Monster
    }
    class Creature
    {
        protected int hp = 0;  // 나중에 상속 받을것이므로 protected 로 선언
        protected int attack = 0;
        CreaturType type;

        protected Creature(CreaturType type)
        {
            this.type = type;
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }

        public int GetHp() { return hp; }
        public int GetAttack() { return attack; }
        public bool IsDead() { return hp <= 0; }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
