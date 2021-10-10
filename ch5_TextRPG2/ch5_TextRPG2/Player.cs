using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch5_TextRPG2
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    class Player : Creature
    {
        protected PlayerType type = PlayerType.None;


        public Player(PlayerType type) : base(CreaturType.Player) // Player를 직접 만드는건 지양하기 위해서 protected로 선언. protected로 선언하면 외부에서 new Player(~) 로 만들수 없게 됨.
        {
            this.type = type;
        }

        public PlayerType GetPlayerType() { return type; }


    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);   // 하드코딩 하는건 안좋은 습관임. 나중에 게임 프로젝트를 실제로 만들게 되면 데이터 관련된건 데이터 파일로 다 뺴게 됨. 파일을 로드해서 값을 입력함
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(50, 15);
        }
    }
}
