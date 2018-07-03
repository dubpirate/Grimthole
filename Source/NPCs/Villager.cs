using System;
using Grimthole.MacOS.Source.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Grimthole.MacOS.Source.NPCs
{
    public class Villager : Entity
    {
        public string Response { get; }

        public Villager(Vector2 coords) 
            : base("Sprites/Man2front", coords, ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
            Response = "It's a good day to live underground.";
        }

        public override void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
        {
            //throw new NotImplementedException();
        }
    }
}
