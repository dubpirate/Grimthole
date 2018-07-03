using Grimthole.Core;

using Microsoft.Xna.Framework;

namespace Grimthole.Controllers
{
	public abstract class Controller
    {
		public abstract void Update(Player player, GameTime gt);
    }
}
