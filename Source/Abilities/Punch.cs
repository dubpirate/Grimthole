using Grimthole.MacOS.Source.Core;

namespace Grimthole.MacOS.Source.Abilities
{
	public class Punch : Attack
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
