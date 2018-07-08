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
        public string Response { get; set; }
        private string texture = "Sprites/Man2front";

        public Villager(Vector2 coords, string texture) 
            : base(texture, coords, ScreenManager.Instance.TileSize, ScreenManager.Instance.TileSize)
        {
            Response = "I eat ass";
            this.texture = texture;
        }

        public override void Update(Rectangle windowDimensions, GameTime gt, ContentManager content)
        {
            //throw new NotImplementedException();
        }

        public void changeHue(ContentManager content)
        {
            Texture2D tex = content.Load<Texture2D>(texture);
            Color[] tcolor = new Color[tex.Width * tex.Height];
            tex.GetData<Color>(tcolor);

            for(int i = 0; i<tcolor.Length; i++ ){
                if (tcolor[i].R > 80 && tcolor[i].G < 100 && tcolor[i].B < 100)
                {
                    byte temp = tcolor[i].B;
                    tcolor[i].B = tcolor[i].R;
                    tcolor[i].R = temp;
                }
            }

            tex.SetData<Color>(tcolor);
        }

        public void revertHue(ContentManager content)
        {
            Texture2D tex = content.Load<Texture2D>(texture);
            Color[] tcolor = new Color[tex.Width * tex.Height];
            tex.GetData<Color>(tcolor);

            for (int i = 0; i < tcolor.Length; i++)
            {
                if (tcolor[i].B > 80 && tcolor[i].G < 100 && tcolor[i].R < 100)
                {
                    byte temp = tcolor[i].R;
                    tcolor[i].R = tcolor[i].B;
                    tcolor[i].B = temp;
                }
            }

            tex.SetData<Color>(tcolor);
        }
    }
}