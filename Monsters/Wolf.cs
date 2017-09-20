using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class Wolf : Monster
    {
        public Wolf()
        {
            Health = 1200;
            Gold = 85;
            XP = 70;
            Name = "Wolf";
            Image = Properties.Resources.Wolf;
        }
    }
}
