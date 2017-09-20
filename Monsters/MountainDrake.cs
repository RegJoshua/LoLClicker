using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class MountainDrake : Monster
    {
        public MountainDrake()
        {
            Health = 108350;
            Gold = 170;
            XP = 375;
            Name = "Mountain Drake";
            Image = Properties.Resources.MountainDrake;
        }
    }
}
