using Grimthole.Controllers;
using Grimthole.Core;
using Grimthole.NPCs;
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
        Texture2D background;
        Rectangle backgroundPosition;
        Texture2D buttonNotSelected;
        Texture2D buttonSelected;
        Rectangle buttonTalkPosition;
        Rectangle buttonShopPosition;
        Villager villager;
        Texture2D villagerTexture;
        String buttonTalk { get; set; }
        String buttonShop { get; set; }
        GameScreen previousScreen;
        double timer = 0.2;
        SpriteFont font72;
        String Title { get; set; }
        int selected = 1;
        Player player;
        Tile floor;
        int chosen = 0;


        public ShopScreen(GameScreen previousScreen, Player player, Villager villager, Tile floor)
        {
            this.previousScreen = previousScreen;
            this.player = player;
            this.villager = villager;
            this.floor = floor;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            backgroundPosition = new Rectangle(new Point(0,0), new Point(ScreenManager.Instance.Dimensions.Width, ScreenManager.Instance.Dimensions.Height));
            background = Content.Load<Texture2D>("Backgrounds/Shop");
            font72 = Content.Load<SpriteFont>("TextFont72");
            Title = "Pete the Potion Seller";
            buttonNotSelected = Content.Load<Texture2D>("Interaction/ButtonNotSelected");
            buttonSelected = Content.Load<Texture2D>("Interaction/ButtonSelected");
            buttonTalkPosition = new Rectangle(new Point(300,700), new Point(350,200));
            buttonShopPosition = new Rectangle(new Point(1100, 700), new Point(350, 200));
            buttonTalk = "Talk";
            buttonShop = "Shop";
            villagerTexture = Content.Load<Texture2D>("Sprites/Man2left"); 
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (chosen == 0)
            {
                spriteBatch.Begin(); //draws background and buttons
                spriteBatch.Draw(background, backgroundPosition, Color.White);
                spriteBatch.DrawString(font72, Title, new Vector2(420, 60), Color.Black);
                if (selected == 1)
                {
                    spriteBatch.Draw(buttonSelected, buttonTalkPosition, Color.White);
                    spriteBatch.Draw(buttonNotSelected, buttonShopPosition, Color.White);
                }
                else if (selected == 2)
                {
                    spriteBatch.Draw(buttonNotSelected, buttonTalkPosition, Color.White);
                    spriteBatch.Draw(buttonSelected, buttonShopPosition, Color.White);
                }

                spriteBatch.DrawString(font72, buttonTalk, new Vector2(380, 740), Color.Black);
                spriteBatch.DrawString(font72, buttonShop, new Vector2(1170, 740), Color.Black);

                for (var i = 0; i < ScreenManager.Instance.Dimensions.Width; i += ScreenManager.Instance.TileSize) //draws cave background behind
                {
                    for (var j = 231; j < 550; j += ScreenManager.Instance.TileSize)
                    {
                        spriteBatch.Draw(Content.Load<Texture2D>("Backgrounds/cave3"), new Vector2(i, j), floor.getSourceRectangle(), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
                    }
                }



                villager.changeHue(Content, villagerTexture); //draws Pete the potion seller
                spriteBatch.Draw(villagerTexture, new Rectangle(new Point(1100, 300), new Point(200, 200)), Color.White);
                spriteBatch.End();
                villager.revertHue(Content, villagerTexture);

                drawPlayer(spriteBatch,gameTime);
                
            } else if (chosen == 1)
            {

            }
            

        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.D)) //changes button selected
            { 
                if (selected == 1 && timer<= 0)
                {
                    selected = 2;
                    timer = 0.2;
                }
                else if (selected ==2 && timer <=0)
                {
                    selected = 1;
                    timer = 0.2;
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && timer <= 0) {  //returns to the previous screen
                   timer = 0.2;
                   ScreenManager.Instance.ChangeScreen(previousScreen);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J)) { //changes screen to display button selection
                if (selected == 1 && timer <= 0) //shows talking 
                {                
                    timer = 0.2;
                    
                }
                else if (selected == 2 && timer <= 0)//shows shop
                {
                    //not implemented yet
                    timer = 0.2;
                }
            }

        }



        public void drawPlayer(SpriteBatch spriteBatch, GameTime gameTime)//draws player
        {
            spriteBatch.Begin(); 
            player.currentAnimation = player.IdleFront;
            var sourceRectangle = player.currentAnimation.CurrentRectangle;
            spriteBatch.Draw(player.getCharacterSilhouette(), new Rectangle(new Point(500, 300), new Point(200, 200)), Color.White);
            spriteBatch.Draw(player.getCharacterSheetTexture(), new Rectangle(new Point(500, 300), new Point(200, 200)), sourceRectangle, Color.White);
            spriteBatch.End();
            player.currentAnimation.Update(gameTime);
        }
    }
}
