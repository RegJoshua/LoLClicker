using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class InfernalDrake : Monster
    {
        public InfernalDrake()
        {
            Health = 118750;
            Gold = 180;
            XP = 425;
            Name = "Infernal Drake";
            Image = Properties.Resources.FireDrake;
        }
    }
}
