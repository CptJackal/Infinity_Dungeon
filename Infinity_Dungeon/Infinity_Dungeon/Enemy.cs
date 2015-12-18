using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity_Dungeon
{
    class Enemy
    {
        Random rnd = new Random();

        public int STR = 1;
        public int DEX = 1;
        public int CON = 1;
        public int health;
        public int AC;
        public int Damage;

        public void create()
        {
            this.STR = rnd.Next(1,5);
            this.DEX = rnd.Next(1,5);
            this.CON = rnd.Next(5,10);

            if (STR + DEX + CON > 10)
            {
                this.create();
            }

            health = 5 * CON;
            AC = 2 * DEX;
            Damage = STR;

        }
        
        public void attack(Player playerOne)
        {
            playerOne.health -= Damage;
        }
    }

}
