using Microsoft.Xna.Framework;

namespace Grimthole.Core
{
    public class Tile
    {
        public enum TileTypes { UnCollidable, Collidable, Damage };
        private TileTypes tileType;
        private Rectangle SourceRectangle;
        public Tile(Rectangle r)
        {
            SourceRectangle = r;
            tileType = TileTypes.UnCollidable;
        }

        public Tile(Rectangle r, TileTypes t)
        {
            SourceRectangle = r;
            tileType = t;
        }

        public Rectangle getSourceRectangle()
        {
            return SourceRectangle;
        }

        public TileTypes GetTileTypes()
        {
            return tileType;
        }
    }
}
