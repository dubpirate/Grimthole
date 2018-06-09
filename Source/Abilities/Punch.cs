using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimthole.Utils;
using Grimthole.Core;

namespace Grimthole.Abilities
{
    class Punch : Ability
    {
        // Fields:
        private readonly int _damage;
        private readonly float _coolDown;
        private readonly float _recoveryTime;

        // Constructor:
        public Punch()
        {
            Name = "Punch";
            _damage = 10;
            _coolDown = 2;
            _recoveryTime = 2;
        }

       
    }
}
