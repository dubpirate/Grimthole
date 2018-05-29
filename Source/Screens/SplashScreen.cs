using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Screens
{
    public class SpashScreen : GameScreen
    {
        Texture2D logo;
        int tileSize;
        Point logoHeightAndWidth;
        ArrayList points = new ArrayList();

        public override void LoadContent()
        {
            base.LoadContent();

            // The logo should appear in the centre of the screen, and slightly
            // above 1/2 way up to make room for the Text.

            // The logo, 1/3 of the screen height.
            tileSize = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 16;
            
            // The top left position of the logo.
            for (int i = 0; i < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; i += tileSize)
            {
                for (int j = 0; j < GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; j += tileSize)
                {
                    points.Add(new Point(i, j));
                }
            }
        
            

            // The height and width of the logo.
            logoHeightAndWidth = new Point(
                tileSize,
                tileSize
            );


            logo = Content.Load<Texture2D>("Backgrounds/Grass-1");
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (Point p in points)
            {
                spriteBatch.Draw(logo, new Rectangle(p, logoHeightAndWidth), Color.White);
            }
            spriteBatch.End();
        }
    }
}
