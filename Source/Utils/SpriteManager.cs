using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Grimthole.Utils
{ 
    public abstract class SpriteManager
    {
        protected String name;
        protected Color[] spriteData;
        protected Texture2D sprite;
        protected Rectangle rectangle;
        protected int width;
        protected int height;
        protected SpriteManager(String name, Vector2 coords, int width, int height)
        {
            // Initialise base sprite details. 
            this.name = name;
            this.width = width;
            this.height = height;
            rectangle = new Rectangle((int)coords.X, (int)coords.Y, this.width, this.height);
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(name);
        }


        public virtual void Update(GraphicsDeviceManager graphics, GameTime gt, ContentManager content)
        {
            // pass
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(sprite, rectangle, Color.White);
            spriteBatch.End();
        }

        public String Name { get; protected set; }

        public Rectangle GetRectangle { get; }
    }
}