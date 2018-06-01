using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Grimthole.MacOS.Source.Utils

{ 
    public abstract class SpriteManager
    {
        protected String name;
        protected Color[] spriteData;
        protected Texture2D sprite;

		public Rectangle SpriteDimensions { get; set; }

        public String Name { get; protected set; }

        protected SpriteManager(String name, Vector2 coords, int width, int height)
        {
            // Initialise base sprite details. 
            this.name = name;

			SpriteDimensions = new Rectangle((int)coords.X, (int)coords.Y, width, height);
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(name);
        }

        public virtual void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
        {
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
			spriteBatch.Draw(sprite, SpriteDimensions, Color.White);
            spriteBatch.End();
        }
    }
}