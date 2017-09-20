using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class RangeMinion : Monster
    {
        public RangeMinion()
        {
            Health = 200;
            Gold = 30;
            XP = 20;
            Name = "Range Minion";
            Image = Properties.Resources.MageMinion;
        }
    }
}
