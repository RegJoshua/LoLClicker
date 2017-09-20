using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLClicker.Monsters
{
    class RiftHerald : Monster
    {
        public RiftHerald()
        {
            Health = 159500;
            Gold = 200;
            XP = 450;
            Name = "Rift Herald";
            Image = Properties.Resources.RiftHerald;
        }
    }
}
