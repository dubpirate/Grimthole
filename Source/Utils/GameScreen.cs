using Grimthole.MacOS.Source.Controllers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Utils
{
    public abstract class GameScreen
    {
        protected ContentManager Content;

		protected Controller controller;

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