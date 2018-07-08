using Grimthole.Interfaces;
using Grimthole.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.Utils
{
    public class TextBubble : ISprite
    {
        Texture2D sprite;

        SpriteFont font;
        int width = 128;
        int height = 64;

        public Rectangle SpritePosition { get; set; }

        public String Text { get; set; }

        public TextBubble(String text, Vector2 coords)
        {
            this.Text = text;
            SpritePosition = new Rectangle((int)coords.X, (int)coords.Y, width, height);
        }

        

        public virtual void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);
            spriteBatch.Draw(sprite, SpritePosition, Color.White);
            spriteBatch.DrawString(font, Text, new Vector2(SpritePosition.X + 10, SpritePosition.Y + 10), Color.Black);
            spriteBatch.End();
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("TextBubble");
            font = content.Load<SpriteFont>("TextFont");
        }

        public void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
        {
            //throw new NotImplementedException();
        }
    }
}
