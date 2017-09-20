using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class CloudDrake : Monster
    {
        public CloudDrake()
        {
            Health = 87250;
            Gold = 150;
            XP = 265;
            Name = "Cloud Drake";
            Image = Properties.Resources.CloudDrake;
        }
    }
}
