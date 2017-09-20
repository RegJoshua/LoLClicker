using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class CannonMinion : Monster
    {       
        public CannonMinion()
        {
            Health = 450;
            Gold = 45;
            XP = 35;
            Name = "Cannon Minion";
            Image = Properties.Resources.Minion;
        }
    }
}
