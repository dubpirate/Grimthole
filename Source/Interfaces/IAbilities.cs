using System;
using Microsoft.Xna.Framework;

namespace Grimthole.Interfaces
{
    /// <summary>
    /// This interfaces is for all the abilities anyone can learn
    /// </summary>
    public interface IAbilities
    {
        String Name { get; }

		void DoAction();
    }
}

