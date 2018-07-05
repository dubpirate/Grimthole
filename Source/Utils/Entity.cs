using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Grimthole.Interfaces;

namespace Grimthole.Utils
{
	/// <summary>
    /// An Entity is any Sprite that is 'alive.'
    /// </summary>
	public abstract class Entity : ISprite
    {
        protected String name;
        protected Texture2D sprite;

		protected int health;
		protected int speed;
		protected int defense;
		protected int magicResistance;

		public String Name { get; protected set; }

		public Rectangle SpritePosition { get; set; }

        // Default Constructor for entities.
		protected Entity(String name, Vector2 coords, int width, int height)
        {
            this.name = name;
			SpritePosition = new Rectangle((int)coords.X, (int)coords.Y, width, height);
        }
        
		public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(name);
        }

		public abstract void Update(Rectangle windowDimensions, GameTime gt, ContentManager content);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
			spriteBatch.Draw(sprite, SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}