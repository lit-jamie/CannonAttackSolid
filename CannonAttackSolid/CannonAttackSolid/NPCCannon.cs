using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackSolid
{
    public class NPCCannon : Cannon, ICalculateParameters
    {
        
        

        public NPCCannon() : base()
        {
            SetParams();
            //targetingStatusStandingBy;
        }
        
        public override Cannon GetInstance()
        {
            lock (base.padlock)
            {
                if (cannonSingletonInstance == null)
                {
                    base.cannonSingletonInstance = new NPCCannon();
                }
                return cannonSingletonInstance;
            }
        }

        public void SetParams()
        {
            Random r = new Random();
            this.Position = r.Next(1000);
            this.SetTarget(2000 - this.Position);
        }

        
    }
}
