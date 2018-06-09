using System;
using System.Collections;
using System.Collections.Generic;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Screens
{
    public class VillageScreen : GameScreen 
    {
        ArrayList tileGrass = new ArrayList();
        ArrayList tiles = new ArrayList();
        Point tileHeightAndWidth;
        List<Point> points = new List<Point>();
        Player player;

        public override void LoadContent()
        {
            base.LoadContent();

            //Draws the player in the middle of the region
            player = new Player(new Vector2((ScreenManager.Instance.Dimensions.Width/2- ScreenManager.Instance.TileSize), (ScreenManager.Instance.Dimensions.Height/2- ScreenManager.Instance.TileSize)));

            player.LoadContent(Content);

            //sets the region that is drawn
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

            
            for (int i = 1; i < 6; i++)
            {
                tileGrass.Add(Content.Load<Texture2D>("Backgrounds//Grass/Grass-"+i)); //Adds the 5 different grasses to a list
            }
            Random rnd = new Random();
            int number = rnd.Next(0, 100);

            //goes through each avaliable tile and chooses a grass tile to go there based on probabilitiy
            foreach (Point point in points)
            {
                number = rnd.Next(0, 100);
                if(number < 45)
                {
                    tiles.Add((Texture2D)tileGrass[0]);
                }
                else if(number < 90)
                {
                    tiles.Add((Texture2D)tileGrass[2]);
                }
                else if(number < 93)
                {
                    tiles.Add((Texture2D)tileGrass[1]);
                }
                else if(number < 97)
                {
                    tiles.Add((Texture2D)tileGrass[3]);
                }
                else
                {
                    tiles.Add((Texture2D)tileGrass[4]);
                }           
            }
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(ScreenManager.Instance.Dimensions, gameTime, Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //draws each tile in the region
            int i = 0;
            foreach (Point point in points)
            {
                spriteBatch.Draw((Texture2D)tiles[i], new Rectangle(point, tileHeightAndWidth), Color.White);
                i++;
            }
            spriteBatch.End();

            player.Draw(spriteBatch);
        }
    }
}