using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Utils
{
    public class Player : SpriteManager
    {
        new static int tileSize = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 16;
        public Player(float xpos, float yPos)
            : base("Sprites/Man2front", new Vector2(xpos, yPos), tileSize, tileSize)
        {

        }

        public override void Update(GraphicsDeviceManager graphics, GameTime gt, ContentManager content)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(
                                               PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                // Get the current state of Controller1
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (capabilities.HasLeftXThumbStick)
                    {
                        // Check the direction in X axis of left analog stick
                   
                    if (state.ThumbSticks.Left.X < -0.5f) 
                        {
                            rectangle.X -= 10;
                            name = "Sprites/Man2left";
                        }
                    if (state.ThumbSticks.Left.X > 0.5f)
                        {
                            rectangle.X += 10;
                            name = "Sprites/Man2right";
                        }
                    if (state.ThumbSticks.Left.Y > 0.5f)
                        {
                            rectangle.Y -= 10;
                            name = "Sprites/Man2back";
                    }
                    if (state.ThumbSticks.Left.Y < -0.5f)
                        {
                            rectangle.Y += 10;
                            name = "Sprites/Man2front";
                    }
                }

            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                    rectangle.X += 5;

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                    rectangle.X -= 5;

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                    rectangle.Y -= 5;

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                    rectangle.Y += 5;
            }

            CheckEdgeCases(graphics);
        }

        void CheckEdgeCases(GraphicsDeviceManager graphics)
        {
            if (rectangle.X < 0)
                rectangle.X = 0;

            if (rectangle.Y < 0)
                rectangle.Y = 0;

            if (rectangle.X > graphics.GraphicsDevice.Viewport.Width)
                rectangle.X = graphics.GraphicsDevice.Viewport.Width;

        }
    }
}