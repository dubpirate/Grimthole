using Microsoft.Xna.Framework;

namespace Grimthole.MacOS.Source.Core
{
    public class Tile
    {
        private Rectangle SourceRectangle;
        public Tile(Rectangle r)
        {
            SourceRectangle = r;
        }

        public Rectangle getSourceRectangle()
        {
            return SourceRectangle;
        }
    }
}
