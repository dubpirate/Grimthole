using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Grimthole.MacOS.Source.Screens;

namespace Grimthole.MacOS.Source.Utils
{
    /// <summary>
    /// This Screen Manager switches between the relevant screens in the game.
    /// </summary>
    public class ScreenManager
    {
        static ScreenManager instance;

        public readonly int TileSize = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 16;
        public Rectangle Dimensions { get; private set; }
        public ContentManager Content { get; private set; }
        GameScreen currentScreen;      

        public static ScreenManager Instance
        {
            get
            {
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
            Dimensions = new Rectangle(
                0,
                0,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 100,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 100
            );
        }

        public void Initialise()
        {
            currentScreen = new SplashScreen();
        }

        public void ChangeScreen(GameScreen gameScreen)
        {
            currentScreen = gameScreen;
            currentScreen.LoadContent();
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