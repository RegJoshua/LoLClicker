using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class WaterDrake : Monster
    {
        public WaterDrake()
        {
            Health = 97750;
            Gold = 170;
            XP = 345;
            Name = "Water Drake";
            Image = Properties.Resources.WaterDrake;
        }
    }
}
