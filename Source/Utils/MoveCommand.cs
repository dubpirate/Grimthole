using System;
using Grimthole.MacOS.Source.Interfaces;
using Microsoft.Xna.Framework;

namespace Grimthole.MacOS.Source.Utils
{

    /// <summary>
	/// This class is uses the Command Software Design Pattern to take a Sprite
	/// and move it in the desired direction by changing it's rectangle.
    /// </summary>
	public static class MoveCommand
    {
		public static void MoveUp(Entity sprite, int delta)
        {
			sprite.SpritePosition = new Rectangle(
				sprite.SpritePosition.X,
				sprite.SpritePosition.Y - delta,
				sprite.SpritePosition.Width,
				sprite.SpritePosition.Height
            );
        }

		public static void MoveDown(Entity sprite, int delta)
        {
			sprite.SpritePosition = new Rectangle(
				sprite.SpritePosition.X,
				sprite.SpritePosition.Y + delta,
				sprite.SpritePosition.Width,
				sprite.SpritePosition.Height
            );
        }

		public static void MoveLeft(Entity sprite, int delta)
        {
			sprite.SpritePosition = new Rectangle(
				sprite.SpritePosition.X - delta,
				sprite.SpritePosition.Y,
				sprite.SpritePosition.Width,
				sprite.SpritePosition.Height
            );
        }

		public static void MoveRight(Entity sprite, int delta)
        {
			sprite.SpritePosition = new Rectangle(
				sprite.SpritePosition.X + delta,
				sprite.SpritePosition.Y,
				sprite.SpritePosition.Width,
				sprite.SpritePosition.Height
			);
        }
    }
}