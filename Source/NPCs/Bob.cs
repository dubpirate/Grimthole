using Grimthole.MacOS.Source.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace Grimthole.MacOS.Source.NPCs
{
	public class Bob : Entity
    {
		protected Bob(Vector2 coords, int width, int height) : base("Bob", coords, width, height)
		{
			health = 10;
			speed = 5;
		}

		public override void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
		{
			// Walk around randomly.
		}
	}
}
