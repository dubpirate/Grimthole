using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Grimthole.Utils
{
    public class man1 : SpriteManager
    {
        public man1(float tileSize, GraphicsDeviceManager graphics, float yPos)
            : base("man1", new Vector2(graphics.GraphicsDevice.Viewport.Width, yPos))
        {

        }


        public int GetX()
        {
            return rectangle.X;
        }

        public double GetTop()
        {
            return rectangle.Top;
        }

        public double GetBottom()
        {
            return rectangle.Bottom;
        }
    }
}