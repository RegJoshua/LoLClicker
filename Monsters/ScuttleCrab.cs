using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker
{
    class ScuttleCrab : Monster
    {
       
        public ScuttleCrab()
        {
            Health = 750;
            Gold = 65;
            XP = 45;
            Name = "Scuttle Crab";
            Image = Properties.Resources.Scuttle;

        }
       
    }
}
