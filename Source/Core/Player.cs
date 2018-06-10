using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using Grimthole.Utils;
using System.Collections.Generic;
using Grimthole.Core;
using Grimthole.Interfaces;
using Grimthole.Screens;
using Grimthole.Abilities;

namespace Grimthole
{
    public class Player : SpriteManager
    {

        //All the players stats
        private readonly String Name;
        private readonly int Health = 100;
        private readonly int Speed = 10;
        private readonly int Armour = 0;
        private readonly int MagicResistance = 0;
        private readonly int Level = 1;
        private readonly int Gold = 0;
        private readonly int Exp = 0;

        List<IAbilities> attacks = new List<IAbilities>(); //A list of all attacks the player knows


        //Constructor
        public Player(Vector2 coords) : base("Sprites/Man2front", coords,
            ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
            attacks.Add(new Punch()); //adds a default punch move to player
        }


        //Updating the current game screen
        internal void Update(Rectangle windowDimensions, GameTime gt, ContentManager content, int encounterRate)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            Boolean moved = false;
            Random rnd = new Random();
            int number = rnd.Next(0, 100);
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
                        moved = true;
                    }

                    if (state.ThumbSticks.Left.X > 0.5f)
                    {
                        MoveCommand.MoveRight(this, delta);
                        name = "Sprites/Man2right";
                        moved = true;
                    }

                    if (state.ThumbSticks.Left.Y > 0.5f)
                    {
                        MoveCommand.MoveDown(this, delta);
                        name = "Sprites/Man2back";
                        moved = true;
                    }

                    if (state.ThumbSticks.Left.Y < -0.5f)
                    {
                        MoveCommand.MoveUp(this, delta);
                        name = "Sprites/Man2front";
                        moved = true;
                    }
                }

            }
            else //if no controller is plugged in
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    MoveCommand.MoveRight(this, delta);
                    name = "Sprites/Man2right";
                    moved = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    MoveCommand.MoveLeft(this, delta);
                    name = "Sprites/Man2left";
                    moved = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    MoveCommand.MoveUp(this, delta);
                    name = "Sprites/Man2back";
                    moved = true;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    MoveCommand.MoveDown(this, delta);
                    name = "Sprites/Man2front";
                    moved = true;
                }
            }

            CheckEdgeCases(windowDimensions);
            LoadContent(content);
            if(encounterRate < number && moved)
            {
               // ScreenManager.Instance.ChangeScreen(new SplashScreen());
            }
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