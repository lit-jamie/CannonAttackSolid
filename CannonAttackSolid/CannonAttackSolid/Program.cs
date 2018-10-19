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
            int MAXDISTANCE = 20000;
            int targetPosition = 0;
            int angle;
            int velocity;
            string playerInput;
            bool quitFlag = false;
            int hits = 0;
            Cannon player = new PlayerCannon();

            player.ID = "";
            assignPlayers(ref targetPosition, MAXDISTANCE, ref player);


            do
            {
                Console.WriteLine("Welcome to Cannon Attack");
                Console.WriteLine("Target Distance: {0} m", targetPosition);
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
                Console.Write("Would you like to play again(Y/N)");
                playerInput = Console.ReadLine();
                if (playerInput.Equals("N") || playerInput.Equals("n"))
                    quitFlag = true;
            } while (!quitFlag);
            Console.WriteLine("You achieved {0} many hits.\n", hits);
        }

        public static void assignPlayers(ref int targetPosition, int MAXDISTANCE, ref Cannon player)
        {
            bool beyondSetUpRange = false;

            Random r = new Random();
            player.Position = 0;


            while (!beyondSetUpRange)
            {

                targetPosition = r.Next(MAXDISTANCE);
                bool player1Greater = (targetPosition > 50) ? true : false;


                switch (player1Greater)
                {
                    case true:
                        player.SetTarget(targetPosition);
                        beyondSetUpRange = true;
                        break;
                    case false:
                        beyondSetUpRange = false;
                        break;
                }


            }
        }
    }
}
