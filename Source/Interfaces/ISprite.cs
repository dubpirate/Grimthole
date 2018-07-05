using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Grimthole.Screens;

namespace Grimthole.Interfaces
{
	public interface ISprite
    {
		Rectangle SpritePosition { get; set; }
		
		void LoadContent(ContentManager content);

		void Update(Rectangle windowDimensions, GameTime gt, ContentManager content);

		void Draw(SpriteBatch spriteBatch, Camera camera);
    }
}