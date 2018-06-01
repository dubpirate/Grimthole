using System;
using Microsoft.Xna.Framework;

namespace Grimthole.MacOS.Source.Utils
{

    /// <summary>
	/// This class is uses the Command Software Design Pattern to take a Sprite
	/// and move it in the desired direction by changing it's rectangle.
    /// </summary>
	public static class MoveCommand
    {
		public static void MoveUp(SpriteManager sprite, int delta)
		{
			sprite.SpriteDimensions = new Rectangle(
				sprite.SpriteDimensions.X,
				sprite.SpriteDimensions.Y - delta,
				sprite.SpriteDimensions.Width,
				sprite.SpriteDimensions.Height
			);
		}

		public static void MoveDown(SpriteManager sprite, int delta)
        {
			sprite.SpriteDimensions = new Rectangle(
				sprite.SpriteDimensions.X,
				sprite.SpriteDimensions.Y + delta,
				sprite.SpriteDimensions.Width,
				sprite.SpriteDimensions.Height
            );
        }

		public static void MoveLeft(SpriteManager sprite, int delta)
        {
			sprite.SpriteDimensions = new Rectangle(
				sprite.SpriteDimensions.X - delta,
				sprite.SpriteDimensions.Y,
				sprite.SpriteDimensions.Width,
				sprite.SpriteDimensions.Height
            );
        }

		public static void MoveRight(SpriteManager sprite, int delta)
        {
			sprite.SpriteDimensions = new Rectangle(
				sprite.SpriteDimensions.X + delta,
				sprite.SpriteDimensions.Y,
				sprite.SpriteDimensions.Width,
				sprite.SpriteDimensions.Height
            );
        }
    }
}
