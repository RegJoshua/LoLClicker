using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Items
{
    class Item
    {
        private int amount;
        private int cost;
        private int damage;
        private double passiveGold;
        private double passiveXP;

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        public double PassiveGold
        {
            get
            {
                return passiveGold;
            }
            set
            {
                passiveGold = value;
            }
        }

        public double PassiveXP
        {
            get
            {
                return passiveXP;
            }
            set
            {
                passiveXP = value;
            }
        }
        


        
    }
}
