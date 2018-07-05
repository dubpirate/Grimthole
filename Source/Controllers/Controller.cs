using Grimthole.Utils;
using Microsoft.Xna.Framework;

namespace Grimthole.Controllers
{
	public abstract class Controller
    {
        public abstract void Update(Entity entity, GameTime gt);
    }
}
