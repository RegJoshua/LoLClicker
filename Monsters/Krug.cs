using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class Krug : Monster
    {
        public Krug()
        {
            Health = 4500;
            Gold = 100;
            XP = 85;
            Name = "Krugs";
            Image = Properties.Resources.Krug;
        }
    }
}
