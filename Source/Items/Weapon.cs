using Grimthole.Core;

namespace Grimthole.Items
{
	/// <summary>
	/// (A Haiku)
	///     Weapon details means
	///     the attack it has
	///     and how to draw it.
    /// </summary>
	public abstract class Weapon : Item
	{
		protected Attack attack;
        
		protected Weapon(string name, Attack attack) : base(name)
		{
			this.attack = attack;
		}
	}
}
