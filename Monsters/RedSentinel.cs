using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class RedSentinel : Monster
    {
        public RedSentinel()
        {
            Health = 15750;
            Gold = 140;
            XP = 245;
            Name = "Red Sentinel";
            Image = Properties.Resources.RedSentinel;
        }
    }
}
