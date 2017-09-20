using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class BlueSentinel : Monster
    {
        public BlueSentinel()
        {
            Health = 11500;
            Gold = 130;
            XP = 225;
            Name = "Blue Sentinel";
            Image = Properties.Resources.BlueSentinel;
        }
    }
}
