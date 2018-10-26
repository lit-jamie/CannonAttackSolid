using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackSolid
{
    class Program
    {
        static void Main(string[] args)
        {
            Begin();
        }

        public static void Begin()
        {
            //int MAXDISTANCE = 20000;
            //int targetPosition;
            int angle;
            int velocity;
            string playerInput;
            bool quitFlag = false;
            int hits = 0;
            Cannon player;
            Cannon npc;
            bool playerHit = false;
            npc = new NPCCannon();
            npc.GetInstance();
            player = new PlayerCannon();
            player.GetInstance();
            player.SetTarget(npc.Position);
            Random r = new Random();
            Console.WriteLine("Welcome to Cannon Attack");
            do
            {

                Console.WriteLine("\nWelcome to Cannon Attack");
                Console.WriteLine("Target Distance: {0} m", player.DistanceOfTarget);
                Console.Write("Enter Angle: ");
                angle = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                Console.Write("Enter Velocity: ");
                velocity = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                Console.WriteLine("+---------------------------+");
                Console.WriteLine("Preparing to fire.\n");
                var x = player.Shoot(angle, velocity);
                Console.WriteLine("Result: {0} {1}", x.Item1, x.Item2);
                if (x.Item1)
                    hits++;

                Console.WriteLine("\nNpc Preparing to fire.\n");

                x = npc.Shoot(Math.Abs(r.Next(120) +10), Math.Abs(r.Next(150) +10));
                Console.WriteLine("Result: {0} {1}", x.Item1, x.Item2);
                if (x.Item1)
                    playerHit = true;
                if (!playerHit)
                {
                    Console.Write("Would you like to play again(Y/N)\t");
                    playerInput = Console.ReadLine();
                    if (playerInput.Equals("N") || playerInput.Equals("n"))
                        quitFlag = true;
                }
                else
                {
                    Console.WriteLine("\n\tGame over, direct Hit!\n");
                    quitFlag = true;
                }
            } while (!quitFlag);
            Console.WriteLine("\nYou achieved {0} many hits.\n", hits);
        }

    }
}
