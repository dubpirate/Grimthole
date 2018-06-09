using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Grimthole.Utils;

namespace Grimthole
{
    public class Player2 : SpriteManager
    {
        public Player2(Vector2 coords) : base("Sprites/Man2front", coords,
            ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
        }

        public override void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            int delta = (int)(gt.ElapsedGameTime.TotalMilliseconds * 0.4);

            if (capabilities.IsConnected)
            {
                // Get the current state of Controller1
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (capabilities.HasLeftXThumbStick)
                {
                    if (state.ThumbSticks.Left.X < -0.5f)
                    {
                        MoveCommand.MoveLeft(this, delta);
                        name = "Sprites/Man2left";
                    }

                    if (state.ThumbSticks.Left.X > 0.5f)
                    {
                        MoveCommand.MoveRight(this, delta);
                        name = "Sprites/Man2right";
                    }

                    if (state.ThumbSticks.Left.Y > 0.5f)
                    {
                        MoveCommand.MoveDown(this, delta);
                        name = "Sprites/Man2back";
                    }

                    if (state.ThumbSticks.Left.Y < -0.5f)
                    {
                        MoveCommand.MoveUp(this, delta);
                        name = "Sprites/Man2front";
                    }
                }

            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.K))
                {
                    MoveCommand.MoveRight(this, delta);
                    name = "Sprites/Man2right";
                }

                if (Keyboard.GetState().IsKeyDown(Keys.H))
                {
                    MoveCommand.MoveLeft(this, delta);
                    name = "Sprites/Man2left";
                }

                if (Keyboard.GetState().IsKeyDown(Keys.U))
                {
                    MoveCommand.MoveUp(this, delta);
                    name = "Sprites/Man2back";
                }

                if (Keyboard.GetState().IsKeyDown(Keys.J))
                {
                    MoveCommand.MoveDown(this, delta);
                    name = "Sprites/Man2front";
                }
            }

            CheckEdgeCases(windowDimensions);
            LoadContent(content);
        }

        /// <summary>
        /// Checks the player has not moved off the edges.
        /// </summary>
		/// <param name="windowDimensions">The dimensions of the game window.</param>
		void CheckEdgeCases(Rectangle windowDimensions)
        {
            if (SpriteDimensions.Left < 0)
            {
                MoveCommand.MoveRight(this, Math.Abs(0 - SpriteDimensions.Left));
            }

            if (SpriteDimensions.Top < 0)
            {
                MoveCommand.MoveDown(this, Math.Abs(0 - SpriteDimensions.Top));
            }

            if (SpriteDimensions.Right > windowDimensions.Width)
            {
                MoveCommand.MoveLeft(this, Math.Abs(windowDimensions.Width - SpriteDimensions.Right));
            }

            if (SpriteDimensions.Bottom > windowDimensions.Height)
            {
                MoveCommand.MoveUp(this, Math.Abs(windowDimensions.Height - SpriteDimensions.Bottom));
            }

        }
    }
}