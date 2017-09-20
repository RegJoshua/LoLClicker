using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class MeleeMinion : Monster
    {
        public MeleeMinion()
        {
            Health = 300;
            Gold = 35;
            XP = 25;
            Name = "Melee Minion";
            Image = Properties.Resources.MeleeMinion;
        }
    }
}
