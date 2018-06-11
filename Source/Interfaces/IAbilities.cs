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

        int Damage { get; }

        float CoolDown { get; }

        float RecoveryTime { get; }

		void Tick(GameTime gameTime);
    }

}

