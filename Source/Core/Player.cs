using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Grimthole.Utils;
using Grimthole.Interfaces;
using Grimthole.Abilities;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Core
{
	public class Player : Entity
    {
        // All the players stats.
		readonly int level = 1;
        readonly int experience = 0;
        public Rectangle pos;
        

		public int Speed { get; }

		// A list of all attacks the player knows.
        List<IAbilities> attacks = new List<IAbilities>();
        
        public Player(Vector2 coords) : base("Sprites/Man2front", coords,
            ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
			health = 100;
			speed = 10;
            attacks.Add(new Punch()); //adds a default punch move to player
            pos = new Rectangle((int)coords.X, (int)coords.Y, SpritePosition.Width, SpritePosition.Height);
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

			if (SpritePosition.Right > ScreenManager.Instance.TileSize*60)
            {
				MoveCommand.MoveLeft(this, Math.Abs(ScreenManager.Instance.TileSize * 60 - SpritePosition.Right));
            }

			if (SpritePosition.Bottom > ScreenManager.Instance.TileSize*40)
            {
				MoveCommand.MoveUp(this, Math.Abs(ScreenManager.Instance.TileSize * 40 - SpritePosition.Bottom));
            }

			LoadContent(content);
		}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, pos, Color.White);
            spriteBatch.End();
        }
	}
}