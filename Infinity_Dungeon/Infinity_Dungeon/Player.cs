using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinity_Dungeon
{
    class Player
    {
        public int health { get; set; }
        private int defence;
        public IWeapon wield { get; set; }
        public IArmour wear;
        private int STR { get; set; }
        private int DEX { get; set; }
        private int CON { get; set; }

        public Player()
        {

        }

        public void create()
        {
            bool attributes = true;

            while (attributes)
            {

                Console.Clear();
                Console.WriteLine("You have 10 points to give to your Strength, Dexerity, or Constitution");
                Console.WriteLine("Strength determines how much damage you do");
                Console.WriteLine("Dexerity determines how well you hit enemies");
                Console.WriteLine("Constitution determines how much health you have");
                Console.WriteLine("");
                Console.WriteLine("What do you want your STR to be?"); STR = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want your DEX to be?"); this.DEX = int.Parse(Console.ReadLine());
                Console.WriteLine("What do you want your CON to be?"); this.CON = int.Parse(Console.ReadLine());

                if (STR + DEX + CON == 10)
                {
                    attributes = false;
                }
                else if (STR + DEX + CON != 10)
                {
                    Console.WriteLine("That's not quite right, please try again");
                }
            }

            bool weapons = true;

            while (weapons)
            {
                Console.WriteLine("Now you can choose your weapon, you can pick Sword, Axe, or Club");
                Console.WriteLine("The Axe does the most damage, but slows you down");
                Console.WriteLine("The Sword does the least damage, but is the fastest");
                Console.WriteLine("The Club is in the middle, but is easier to block with");
                Console.WriteLine("");
                Console.WriteLine("write AXE, SWORD, or CLUB to pick your weapon");
                string weaponChoice = Console.ReadLine();

                switch (weaponChoice)
                {
                    case "AXE":
                        wield = new Axe();
                        weapons = false;
                        break;
                    case "SWORD":
                        wield = new Sword();
                        weapons = false;
                        break;
                    case "CLUB":
                        wield = new Club();
                        weapons = false;
                        break;

                    default:
                        break;
                }
            }

            bool armours = true;

            while (armours)
            {
                Console.WriteLine("Now you can choose your armour, you can pick LEATHER or METAL");
                Console.WriteLine("The Metal stops the most damage, but slows you down");
                Console.WriteLine("The Leather stops the least damage, but is the fastest");
                Console.WriteLine("");
                Console.WriteLine("write LEATHER or ME to pick your armour");
                string armourChoice = Console.ReadLine();

                switch (armourChoice)
                {
                    case "LEATHER":
                        wear = new Leather();
                        armours = false;
                        break;
                    case "METAL":
                        wear = new Metal();
                        armours = false;
                        break;
                    default:
                        break;
                }
            }
            health = CON * 5;
            Console.Clear();
            Console.WriteLine("You stand before the great hall of the Goblin Lich lord. In front of you stand his two Leutenants stand at the ready, each wearing one of the"); 
            Console.WriteLine("two keys required to detroy the lich's infernal machine around their necks");
            Console.WriteLine("");
            Console.WriteLine("The first rushes you with his axe while the other waits");
            Console.WriteLine("");
            Console.WriteLine("(type ATTACK to attack, DEFEND to block)");
            
        }

        public void attack( Enemy current)
        {
            current.health -= STR+ wield.damage();
        }

        public void defend()
        {
            defence = wear.AC() + DEX;
            Console.WriteLine("Defend");
        }

        }
    }
