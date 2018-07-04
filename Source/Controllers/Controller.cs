using Grimthole.MacOS.Source.Utils;
using Microsoft.Xna.Framework;

namespace Grimthole.MacOS.Source.Controllers
{
	public abstract class Controller
    {
        public abstract void Update(Entity entity, GameTime gt);
    }
}
