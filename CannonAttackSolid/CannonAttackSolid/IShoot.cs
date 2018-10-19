using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonAttackSolid
{
    interface IShoot
    {
        Tuple<bool, string> Shoot(int angle, int velocity);
    }
}
