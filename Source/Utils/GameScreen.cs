using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Utils
{
    public class GameScreen
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

		public virtual void Update(GameTime gameTime)
		{
			
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			
		}
    }
}
