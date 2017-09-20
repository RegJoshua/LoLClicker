using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Items
{
    class Boots : Item
    {
        public Boots()
        {
            Amount = 0;
            Cost = 300;
            Damage = 3;
            PassiveGold = 2;
            PassiveXP = .8;
        }
    }
}
