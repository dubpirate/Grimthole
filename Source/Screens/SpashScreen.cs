using System;

using Grimthole.MacOS.Source.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Screens
{
	public class SpashScreen : GameScreen
    {
		Texture2D logo;
		Rectangle logoPosition;
		int logoSize;

		public override void LoadContent()
		{         
			base.LoadContent();

            // The logo should appear in the centre of the screen, and slightly
            // above 1/2 way up to make room for the Text.

            // The logo, 1/3 of the screen height.
			logoSize = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 3;

            // The top left position of the logo.
			Point logoTopLeftPosition = new Point(
				(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - (logoSize / 2),
				(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - 4 * (logoSize / 5)
			);

            // The height and width of the logo.
			Point logoHeightAndWidth = new Point(
				logoSize,
				logoSize
			);

            // The rectangle that the logo fills.
			logoPosition = new Rectangle(
				logoTopLeftPosition,
                logoHeightAndWidth
			);
            
			logo = Content.Load<Texture2D>("Logos/logo");
		}

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(logo, logoPosition, Color.White);
			spriteBatch.End();
		}
	}
}
