using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Interfaces
{
   	public interface IItem
	{
		Texture2D Texture { get; }

		Rectangle Dimensions { get; set; }

		void LoadContent(ContentManager content);

		void Update(GameTime gt, ContentManager content);

		void Draw(SpriteBatch spriteBatch);
    }
}
