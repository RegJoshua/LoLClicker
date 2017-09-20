using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Items
{
    class Spellthief : Item
    {
        public Spellthief()
        {
            Amount = 0;
            Cost = 350;
            Damage = 5;
            PassiveGold = 3;
        }
    }
}
