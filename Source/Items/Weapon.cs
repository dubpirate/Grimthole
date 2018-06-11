using Grimthole.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Items
{
	public abstract class Weapon : IItem, IAttacks
	{
		// Item Interface Auto Properties:
		protected Texture2D texture;
		public Texture2D Texture { get; }

		protected Rectangle dimensions;
		public Rectangle Dimensions { get; set; }


		// Attacks Interface Auto Properties:
		protected string name;
        public string Name { get; }

		protected int damage;
		public int Damage { get; }

		protected float coolDown;
		public float CoolDown { get; }

		protected float recoveryTime;
		public float RecoveryTime { get; }

		// Item Interface Method Overrides:
		public abstract void LoadContent(ContentManager content);

		public abstract void Update(GameTime gt, ContentManager content);

		public abstract void Draw(SpriteBatch spriteBatch);

		// AttackMethodOverrides:
		public abstract void Tick(GameTime);
        
		public abstract void MakeSound();
    }
}
