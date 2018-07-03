﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.Core
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
