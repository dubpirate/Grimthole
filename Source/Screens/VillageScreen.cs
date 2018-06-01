using System;
using System.Collections.Generic;

using Grimthole.MacOS.Source.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Screens
{
    public class VillageScreen : GameScreen
    {
        Texture2D tile;
        Point tileHeightAndWidth;
		List<Point> points = new List<Point>();
        
        Player player;

		public override void LoadContent()
        {
			base.LoadContent();
            
            player = new Player(new Vector2(200, 200));         
            player.LoadContent(Content);         
            
            // The top left position of each background tile.
			for (var i = 0; i < ScreenManager.Instance.Dimensions.Width; i += ScreenManager.Instance.TileSize)
            {
				for (var j = 0; j < ScreenManager.Instance.Dimensions.Height; j += ScreenManager.Instance.TileSize)
                {
                    points.Add(new Point(i, j));
                }
            }

            // The height and width of the tiles.
            tileHeightAndWidth = new Point(
				ScreenManager.Instance.TileSize,
				ScreenManager.Instance.TileSize
            );         

            tile = Content.Load<Texture2D>("Backgrounds/Grass-1");
        }

        public override void Update(GameTime gameTime)
        {
			player.Update(ScreenManager.Instance.Dimensions, gameTime, Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
		{
            spriteBatch.Begin();
            foreach (Point point in points)
            {
                spriteBatch.Draw(tile, new Rectangle(point, tileHeightAndWidth), Color.White);
            }         
            spriteBatch.End();

			player.Draw(spriteBatch);
        }
	}
}
