using Grimthole.Core;

namespace Grimthole.Abilities
{
	class Kick : Attack
    {
        // Fields:
        readonly int _damage;
        readonly float _coolDown;
        readonly float _recoveryTime;

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
