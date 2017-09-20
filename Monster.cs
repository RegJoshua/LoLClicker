using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LoLClicker
{
    class Monster
    {
        private int health;
        private int gold;
        private int xp;
        private string name;
        private Image image;
        
        
        
        public Monster()
        {
            health = 0;
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }

        }

        public int Gold
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

        public int XP
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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        
    

    }
}
