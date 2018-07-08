﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Grimthole.Screens;
using System.Collections.Generic;

namespace Grimthole.Utils
{
    /// <summary>
    /// This Screen Manager switches between the relevant screens in the game.
    /// </summary>
    public class ScreenManager
    {
        static ScreenManager instance;

        public readonly int TileSize = 64;
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
            if (!currentScreen.loadedBefore)
            {
                currentScreen.LoadContent();
            } else
            {
                currentScreen.changeScreenTimer = 0.2;
            }
            
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

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            currentScreen.Draw(spriteBatch,  gameTime);
        }
    }
}