using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimthole.Core;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Screens
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        float posX = 0 ;
        float posY = 0 ;

        public void Follow (Player target, Rectangle dim)
        {
            posY = -target.SpritePosition.Y - (target.SpritePosition.Height / 2);
            posX = -target.SpritePosition.X - (target.SpritePosition.Width / 2);
            
            var position = Matrix.CreateTranslation(
                posX, 
                posY,
                0);


            var offset = Matrix.CreateTranslation(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2 -70, 
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2 -70,
                0);
            
            Transform = position * offset;


        }
    }
}
