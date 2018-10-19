using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackSolid
{
    public class NPCCannon : Cannon
    {
        protected int[] strikePatterns = new int[2];
        public enum TargetStrike { Miss, DirectHit, StandingBy};
        public enum TargetSights { IceCold, Cold, Warm, Hot };
        protected TargetSights targetingStatus;
        protected TargetStrike strikeStatus;

        public NPCCannon() : base()
        {
            strikePatterns[0] = 0;
            strikePatterns[1] = 0;
            //targetingStatusStandingBy;
        }

        public override Cannon GetInstance()
        {
            lock (base.padlock)
            {
                if (cannonSingletonInstance == null)
                {
                    base.cannonSingletonInstance = new PlayerCannon();
                }
                return cannonSingletonInstance;
            }
        }

        public virtual void ProcessTurn()
        {

        }
    }
}
