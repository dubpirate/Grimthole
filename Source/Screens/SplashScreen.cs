using System;

using Grimthole.MacOS.Source.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Screens
{
	public class SplashScreen : GameScreen
    {
		Texture2D logo;
		Rectangle logoPosition;
		double timer;

		public override void LoadContent()
		{         
			base.LoadContent();

            // We only want to spend 4 seconds on the splash screen.
			timer = 4;

			// The logo should appear in the centre of the screen, and slightly
			// above 1/2 way up to make room for the Text.
            
			// The logo dimensions are the (screen height / 3 * screen height / 3).
			int logoSize = ScreenManager.Instance.Dimensions.Height / 3;
            
			Point topLeftPosition = new Point(
				(ScreenManager.Instance.Dimensions.Width / 2) - (logoSize / 2),
				(ScreenManager.Instance.Dimensions.Height / 2) - 4 * (logoSize / 5));

			Point heightAndWidth = new Point(
				logoSize,
				logoSize);
            
            // The rectangle that the logo fills.
			logoPosition = new Rectangle(
				topLeftPosition,
                heightAndWidth);
            
			logo = Content.Load<Texture2D>("Logos/logo");
		}

		public override void Update(GameTime gameTime)
		{
			if (timer > 0) 
			{
				timer -= gameTime.ElapsedGameTime.TotalSeconds;
			}
			else
			{
				ScreenManager.Instance.ChangeScreen(new VillageScreen());
			}
		}
        
		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(logo, logoPosition, Color.White);
			spriteBatch.End();
		}
	}
}
