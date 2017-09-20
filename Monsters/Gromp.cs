using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class Gromp : Monster
    {
        public Gromp()
        {
            Health = 8700;
            Gold = 110;
            XP = 200;
            Name = "Gromp";
            Image = Properties.Resources.Gromp;
        }
    }
}
