using Grimthole.Controllers;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimthole.Screens
{
    public class ShopScreen : GameScreen
    {
        Texture2D texture;
        Rectangle texturePosition;
        GameScreen previousScreen;
        Boolean talking = false;
        Boolean doneTalking = true;
        double timer = 0;

        public ShopScreen(GameScreen previousScreen)
        {
            this.previousScreen = previousScreen;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            texturePosition = new Rectangle(new Point(0,0), new Point(ScreenManager.Instance.Dimensions.Width, ScreenManager.Instance.Dimensions.Height));
            texture = Content.Load<Texture2D>("Logos/logo");
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, texturePosition, Color.White);
            spriteBatch.End();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            if (timer > 0)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                doneTalking = true;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.J)){
                if(!talking && doneTalking)
                {
                    doneTalking = false;
                    timer = 0.5;
                    
                    talking = true;
                }
                else if (doneTalking)
                {
                    doneTalking = false;
                    talking = false;
                    timer = 0.5;
                    ScreenManager.Instance.ChangeScreen(previousScreen);
                }
                
            }
        }
    }
}
