using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Grimthole.MacOS.Source.Utils
{
    public class ScreenManager
    {
		public static ScreenManager instance;
		public Vector2 dimensions { get; private set; }

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
        }

		public void Initialise(GraphicsAdapter graphicsAdapter)
		{
			
		}

		public void LoadContent(ContentManager content)
		{
			
		}

		public void Update(GameTime gameTime)
		{
			
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			
		}
    }
}
