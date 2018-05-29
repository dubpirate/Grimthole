using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


using Grimthole.Utils;
namespace Grimthole
{
    /// <summary>
    /// This is the main type for Grimthole.
    /// </summary>
    public class Grimthole : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;

        public Grimthole()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void BeginRun()
        {
            // TODO: Code for splashscreen with M1 Logo.
            base.BeginRun();
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.ApplyChanges();
            player = new Player(200, 200);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            ScreenManager.Instance.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(graphics, gameTime, Content);
            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            player.Draw(spriteBatch);
            ScreenManager.Instance.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}