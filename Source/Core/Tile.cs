using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
