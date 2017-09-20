using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Items
{
    class Berserker : Item
    {
        public Berserker()
        {
            Amount = 0;
            Cost = 900;
            Damage = 10;
            PassiveXP = 1.5;
            PassiveGold = 3;
        }
    }
}
