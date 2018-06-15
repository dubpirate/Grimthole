using Grimthole.MacOS.Source.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Items
{
	public abstract class Item
    {
		protected string name;
        protected Texture2D sprite;

        public Rectangle SpritePosition { get; set; }

        protected Item(string name)
        {
            this.name = name;
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(name);
        }

        public abstract void Update(Rectangle windowDimensions, GameTime gt, ContentManager content);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, SpritePosition, Color.White);
            spriteBatch.End();
        }
    }
}
