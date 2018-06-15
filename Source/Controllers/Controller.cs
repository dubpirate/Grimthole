using Grimthole.MacOS.Source.Core;

using Microsoft.Xna.Framework;

namespace Grimthole.MacOS.Source.Controllers
{
	public abstract class Controller
    {
		public abstract void Update(Player player, GameTime gt);
    }
}
