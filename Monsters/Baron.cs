using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class Baron : Monster
    {
        public Baron()
        {
            Health = 219000;
            Gold = 275;
            XP = 425;
            Name = "Baron";
            Image = Properties.Resources.Baron;
        }
    }
}
