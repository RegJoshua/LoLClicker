using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class Poro : Monster
    {
        public Poro()
        {
            Health = 250000;
            Gold = 500;
            XP = 450;
            Name = "King Poro";
            Image = Properties.Resources.Poro;
        }
    }
}
