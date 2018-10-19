using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackSolid
{
    public class PlayerCannon : Cannon
    {
        public PlayerCannon() : base()
        {
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
        
    }
}
