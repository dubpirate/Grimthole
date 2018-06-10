using Grimthole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.Core
{
    public class Ability : IAbilities
    {
        public Ability()
        {

        }
        public String Name { get; protected set; }

        public int Damage { get; protected set; }

        public float CoolDown { get; protected set; }

        public float RecoveryTime { get; protected set; }

        public void Tick()
        {
            if (CoolDown > 0)
            {
                CoolDown--;
            }
        }

    }
}
