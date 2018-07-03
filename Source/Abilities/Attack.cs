using Grimthole.MacOS.Source.Interfaces;
using System;

namespace Grimthole.MacOS.Source.Core
{
	public abstract class Attack : IAbilities
    {
        public String Name { get; protected set; }

        public int Damage { get; protected set; }

        public float CoolDown { get; protected set; }

        public float RecoveryTime { get; protected set; }

        /// <summary>
		/// (A Haiku)
		///     The Default attack:
		///     Target's health minus damage,
		///     Set Actor's CoolDown.
        /// </summary>
		public void DoAction()
		{
			// From (Somewhere) get Actor (whoever made the Kick), Target;
            // target.health -= Damage;
			// actor.cooldown = CoolDown;
		}
    }
}
