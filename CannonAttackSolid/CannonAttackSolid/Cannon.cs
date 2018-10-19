using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackSolid 
{
    public abstract class Cannon : IShoot, IGetCannonInstance, ICalculateDistanceOfShot, ISetTarget
    {
        private readonly string CANNONID = "Human";
        public static readonly int MAXANGLE = 90;
        public static readonly int MINANGLE = 1;
        private readonly int MAXVELOCITY = 300000000;
        private readonly int MAXDISTANCEOFTARGET = 20000;
        private readonly int BURSTRADIUS = 50;
        private string CannonID;
        private readonly double GRAVITY = 9.8;
        public int DistanceToTarget
        {
            get { return this.DistanceOfTarget; }
        }
        public int Position { get; set; }
        public string ID
        {
            get
            {
                return (String.IsNullOrWhiteSpace(CannonID)) ? CANNONID : CannonID;
            }
            set
            {
                CannonID = value;
            }
        }
        public int DistanceOfTarget { get => DistanceOfTarget1; set => DistanceOfTarget1 = value; }
        public int DistanceOfTarget1 { get; set; }

        protected Cannon cannonSingletonInstance;
        protected readonly object padlock = new object();
        public  Cannon()
        {

        }
        public abstract Cannon GetInstance();
        
            
        

        public Tuple<bool, string> Shoot(int angle, int velocity)
        {
            if (angle > MAXANGLE || angle < MINANGLE) // angle must be between 0 & 90 degrees.
            {
                return Tuple.Create(false, "Angle Incorrect");
            }
            if (velocity > MAXVELOCITY)
            {
                return Tuple.Create(false, "Velocity of the cannon cannot travel faster than the speed of light");
            }

            string message;
            bool hit;
            int distanceOfShot = CalculateDistanceOfCannonShot(angle, velocity);
            if (distanceOfShot.WithinRange(this.DistanceOfTarget, BURSTRADIUS))
            {
                message = "Hit";
                hit = true;
            }
            else
            {
                message = String.Format("Missed cannonball landed at {0} meters", distanceOfShot);
                hit = false;
            }
            return Tuple.Create(hit, message);
        }

        public int CalculateDistanceOfCannonShot(int angle, int velocity)
        {
            int time = 0;
            double height = 0;
            double distance = 0;
            double angleInRadians = (3.1415926596 / 180) * angle;
            while (height >= 0)
            {
                time++;
                distance = velocity * Math.Cos(angleInRadians) * time;
                height = (velocity * Math.Sin(angleInRadians) * time) - (GRAVITY * Math.Pow(time, 2)) / 2;
            }
            return (int)distance;
        }

        public void SetTarget(int newdistanceOfTarget)
        {
            if (!newdistanceOfTarget.Between(0, MAXDISTANCEOFTARGET))
            {
                throw new ApplicationException(String.Format("Target distance must be between 1 & {0} meters", MAXDISTANCEOFTARGET));
            }
            this.DistanceOfTarget = newdistanceOfTarget;
        }
    }
}
