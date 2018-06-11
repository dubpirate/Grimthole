using System;

namespace Grimthole.Interfaces
{
    /// <summary>
    /// This interfaces is for all the abilities anyone can learn
    /// </summary>
	public interface IAttacks : IAbilities
	{
		void MakeSound();
    }
}

