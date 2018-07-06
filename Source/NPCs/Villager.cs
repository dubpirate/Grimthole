using System;
using Grimthole.Screens;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.NPCs
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
