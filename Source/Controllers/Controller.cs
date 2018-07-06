using Grimthole.Core;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Grimthole.Controllers
{
	public abstract class Controller
    {
        public abstract void Update(Entity entity, GameTime gt, List<Entity> npcs, List<Tile> map, List<Vector2> points);
    }
}
