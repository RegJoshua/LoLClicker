using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class Raptor : Monster
    {
        public Raptor()
        {
            Health = 1300;
            Gold = 70;
            XP = 60;
            Name = "Raptor";
            Image = Properties.Resources.Raptors;
        }
    }
}
