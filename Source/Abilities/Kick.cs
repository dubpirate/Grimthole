using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimthole.Utils;
using Grimthole.Core;

namespace Grimthole.Abilities
{
    class Kick : Ability
    {
        // Fields:
        private readonly int _damage;
        private readonly float _coolDown;
        private readonly float _recoveryTime;

        // Constructor:
        public Kick()
        {
            Name = "Kick";
            _damage = 15;
            _coolDown = 3;
            _recoveryTime = 3;
        }

       
    }
}
