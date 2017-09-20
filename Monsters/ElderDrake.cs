using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class ElderDrake : Monster
    {
        public ElderDrake()
        {
            Health = 188000;
            Gold = 250;
            XP = 425;
            Name = "Elder Drake";
            Image = Properties.Resources.ElderDrake;
        }
    }
}
