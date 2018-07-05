using Grimthole.Core;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Grimthole.Screens
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public Matrix playerTransform { get; private set; }
        float posX = 0 ;
        float posY = 0 ;
        Boolean playerMoveX;
        Boolean playerMoveY;

        public void Follow (Player target, int width, int height)
        {
            playerMoveX = false;
            playerMoveY = false;
            float playerPosX = 0;
            float playerPosY = 0;
            float posXDisplayed = posX;
            float posYDisplayed = posY;
            playerTransform = Matrix.Identity;



            var offset = Matrix.CreateTranslation(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 80,
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - 80,
                0);

            





            //moves player at boundary cases
            if (target.SpritePosition.X < ScreenManager.Instance.Dimensions.Width / 2 - ScreenManager.Instance.TileSize) //horizontal case
            {
                playerMoveX = true;
                playerPosX = (-target.SpritePosition.X - (target.SpritePosition.Width) + ScreenManager.Instance.Dimensions.Width / 2) *-1;
            }
            if (target.SpritePosition.X > ScreenManager.Instance.TileSize * (width - 2) - (ScreenManager.Instance.Dimensions.Width / 2 - ScreenManager.Instance.TileSize)) //horizontal case
            {
                playerMoveX = true;
                playerPosX = target.SpritePosition.X - (ScreenManager.Instance.TileSize * (width - 2) - (ScreenManager.Instance.Dimensions.Width / 2 - ScreenManager.Instance.TileSize));
            }

            if (target.SpritePosition.Y < ScreenManager.Instance.Dimensions.Height / 2 - ScreenManager.Instance.TileSize) //vertical case
            {
                playerPosY = (-target.SpritePosition.Y - (target.SpritePosition.Height) + ScreenManager.Instance.Dimensions.Height / 2) *-1;
                playerMoveY = true;
            }
            if (target.SpritePosition.Y > ScreenManager.Instance.TileSize * (height-2) - (ScreenManager.Instance.Dimensions.Height / 2 - ScreenManager.Instance.TileSize)) //vertical case
            {
                playerPosY = target.SpritePosition.Y - (ScreenManager.Instance.TileSize * (height - 2) - (ScreenManager.Instance.Dimensions.Height / 2 - ScreenManager.Instance.TileSize));
                playerMoveY = true;
            }




            if (playerMoveX || playerMoveY)
            {
                var playerMatrix = Matrix.CreateTranslation(playerPosX, playerPosY, 0);
                playerTransform = playerMatrix;
                
            }

            //changes camera for non-player tiles when player is not moved
            if (!playerMoveX)
            {
                posX = -target.SpritePosition.X - (target.SpritePosition.Width / 2);
            }
            if (!playerMoveY)
            {
                posY = -target.SpritePosition.Y - (target.SpritePosition.Height / 2);
            }

            //moves background and all non-player entities around the screen
            var position = Matrix.CreateTranslation(
                posX,
                posY,
                0);

            Transform = position * offset;
        }
    }
}
