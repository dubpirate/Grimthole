using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Utils
{
    public abstract class GameScreen
    {
        protected ContentManager Content;

        public virtual void LoadContent()
        {
            // Get the content from the Screen Manager
            Content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider,
                "Content"
            );
        }

        public virtual void UnloadContent()
        {
            Content.Dispose();
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}