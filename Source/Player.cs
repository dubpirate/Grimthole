using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Grimthole.Utils
{
    public class Player : SpriteManager
    {
        public Player(float xpos, float yPos)
            : base("Sprites/Man2front", new Vector2(xpos, yPos), 100, 100)
        {

        }

        public override void Update(GraphicsDeviceManager graphics, GameTime gt, ContentManager content)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                rectangle.X += 5;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                rectangle.X -= 5;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                rectangle.Y -= 5;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                rectangle.Y += 5;

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