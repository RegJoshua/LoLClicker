using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker
{
    public class Player
    {
        private double gold;
        private int level;
        private int damage;
        private double xp;
        private int clicks;
        
        public Player()
        {
            gold = 500;
            level = 1;
            damage = 10;
            xp = 0;
        }

        public double Gold
        {
            get
            {
                return gold;
            }
            set
            {
                gold = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
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

        public double XP
        {
            get
            {
                return xp;
            }
            set
            {
                xp = value;
            }
        }
        
        public int Clicks
        {
            get
            {
                return clicks;
            }
            set
            {
                clicks = value;
            }
        }
    }
}
