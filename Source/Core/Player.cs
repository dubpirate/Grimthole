using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Grimthole.MacOS.Source.Utils;
using Grimthole.MacOS.Source.Interfaces;
using Grimthole.MacOS.Source.Abilities;

namespace Grimthole.MacOS.Source.Core
{
	public class Player : Entity
    {
        // All the players stats.
		readonly int level = 1;
        readonly int experience = 0;

		public int Speed { get; }

		// A list of all attacks the player knows.
        List<IAbilities> attacks = new List<IAbilities>();
        
        public Player(Vector2 coords) : base("Sprites/Man2front", coords,
            ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
			health = 100;
			speed = 10;
            attacks.Add(new Punch()); //adds a default punch move to player
        }

		public override void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
		{
			if (SpritePosition.Left < 0)
            {
				MoveCommand.MoveRight(this, Math.Abs(0 - SpritePosition.Left));
            }

			if (SpritePosition.Top < 0)
            {
				MoveCommand.MoveDown(this, Math.Abs(0 - SpritePosition.Top));
            }

			if (SpritePosition.Right > windowDimensions.Width)
            {
				MoveCommand.MoveLeft(this, Math.Abs(windowDimensions.Width - SpritePosition.Right));
            }

			if (SpritePosition.Bottom > windowDimensions.Height)
            {
				MoveCommand.MoveUp(this, Math.Abs(windowDimensions.Height - SpritePosition.Bottom));
            }

			LoadContent(content);
		}
	}
}