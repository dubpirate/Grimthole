using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Grimthole.MacOS.Source.Screens;

namespace Grimthole.MacOS.Source.Utils
{
    public class ScreenManager
    {
		static ScreenManager instance;
		public Vector2 dimensions { get; private set; }
		public ContentManager Content { get; private set; }

		GameScreen currentScreen;

		public static ScreenManager Instance 
		{
			get{
				if (instance == null)
                {
                    instance = new ScreenManager();
                }

				return instance;
			}
		}

        ScreenManager()
        {
			// Set to Full Screen
			dimensions = new Vector2(
				GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
				GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
			);

			currentScreen = new SpashScreen();
        }

		public void Initialise(GraphicsAdapter graphicsAdapter)
		{
			
		}

		public void LoadContent(ContentManager content)
		{
			Content = new ContentManager(content.ServiceProvider, "Content");
			currentScreen.LoadContent();
		}

		public void Update(GameTime gameTime)
		{
			currentScreen.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			currentScreen.Draw(spriteBatch);
		}
    }
}
