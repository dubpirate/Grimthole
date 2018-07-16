using Grimthole.Controllers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Grimthole.Utils
{
    public abstract class GameScreen
    {
        protected ContentManager Content;

		protected Controller controller;

        public double changeScreenTimer = 0;

        public Boolean loadedBefore = false;

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

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public abstract void Save();
    }
}