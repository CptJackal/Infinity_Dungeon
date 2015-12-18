using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infinity_Dungeon
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ready Player One...");
            Console.WriteLine("Press 1 to begin");
            Console.WriteLine("Press 2 to quit");

            while (true)
            {
                
                string choice = Console.ReadLine();

                if (choice == "2")
                {
                    Environment.Exit(0);
                }
                else if (choice == "1")
                {

                    bool play = false;
                    int deadCount = 0;
                    Player playerOne = new Player();

                    Enemy LT1 = new Enemy();
                    Enemy LT2 = new Enemy();

                    playerOne.create();

                    Beginning:
                    LT1.create();
                    LT2.create();

                    Enemy currentEnemy = LT1;

                    play = true;

                    while (play)
                    {
                        string command = Console.ReadLine();
                        string[] words = command.Split(' ');

                        switch (words[0])
                        {
                            case "ATTACK":
                                playerOne.attack(currentEnemy);
                                break;
                            case "DEFEND":
                                playerOne.defend();
                                break;
                            case "INVENTORY":
                                Console.WriteLine(playerOne.wield.GetType());
                                Console.WriteLine(playerOne.wear.GetType());
                                break;

                            default:
                                Console.WriteLine("I do not understand, please use proper commands so you do not get hurt");
                                break;

                        }

                        currentEnemy.attack(playerOne);
                        if (playerOne.health < 1)
                        {
                            Console.WriteLine("THIS IS THE ONLY WAY THIS COULD HAVE ENDED");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        if (currentEnemy.health<1)
                        {
                            if (deadCount < 1)
                            {
                                Console.WriteLine("The Goblin drops dead and you rip the key from his neck, his partner advances on you and prepares to attack");
                                deadCount++;
                                currentEnemy = LT2;
                            }
                            else
                            {
                                Console.WriteLine("The partner drops dead as you land the last blow. You take the key from his neck and activate the magic machine, around you the tower begins to crumble and collapse");
                                Console.WriteLine("Congratulations you saved the world from the GOlblin Lich");
                                Console.WriteLine("WHY DOES THIS FEEL FAMILIAR!?");
                                Console.ReadLine();
                                deadCount = 0;
                                goto Beginning;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Try again");
                }
            }
        }
    }
}
