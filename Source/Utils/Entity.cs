using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Grimthole.Interfaces;
using Grimthole.Screens;
using Grimthole.Core;
using System.Collections.Generic;

namespace Grimthole.Utils
{
	/// <summary>
    /// An Entity is any Sprite that is 'alive.'
    /// </summary>
	public abstract class Entity : ISprite
    {
        protected String name;
        protected Texture2D characterSheetTexture;
        protected Texture2D characterSilhouette;
        Animation RunRight;
        Animation RunLeft;
        Animation RunUp;
        Animation RunDown;
        List<Animation> animations = new List<Animation>();

        protected int health;
        protected int speed;
        protected int defense;
        protected int magicResistance;

        public String Name { get; protected set; }

        public Rectangle SpritePosition { get; set; }

        public Animation currentAnimation { get; set; }

        public Animation IdleFront { get; set; }

        public Animation IdleRight { get; set; }

        public Animation IdleBack { get; set; }

        public Animation IdleLeft { get; set; }

        // Default Constructor for entities.
        protected Entity(String name, Vector2 coords, int width, int height)
        {
            this.name = name;
			SpritePosition = new Rectangle((int)coords.X, (int)coords.Y, width, height);

            IdleFront = new Animation();
            IdleBack = new Animation();
            IdleLeft = new Animation();
            IdleRight = new Animation();
            RunLeft = new Animation();
            RunRight = new Animation();
            RunUp = new Animation();
            RunDown = new Animation();
            animations.Add(IdleFront);
            animations.Add(IdleRight);
            animations.Add(IdleBack);
            animations.Add(IdleLeft);
            /*
            
            animations.Add(RunLeft);
            animations.Add(RunRight);
            animations.Add(RunUp);
            animations.Add(RunDown);
            */
            //top row
            int column = 0;
            foreach (var animation in animations)
            {
                int i = 64;
                int size = 64;
                animation.AddFrame(new Rectangle(0, column, size, size), TimeSpan.FromSeconds(.07));
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                i += size;
                //animation.AddFrame(new Rectangle(i, column, size, size), TimeSpan.FromSeconds(.07));
                column += size;
            }
            currentAnimation = IdleFront;
        }
        
		public void LoadContent(ContentManager content)
        {
            characterSheetTexture = content.Load<Texture2D>(name);
            characterSilhouette = content.Load<Texture2D>("Sprites/Player/ni");

        }

		public abstract void Update(Rectangle windowDimensions, GameTime gt, ContentManager content);

        public virtual void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);
            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(characterSilhouette, SpritePosition, Color.White);
            spriteBatch.Draw(characterSheetTexture, SpritePosition, sourceRectangle, Color.White);
            spriteBatch.End();
        }



        public Texture2D getCharacterSheetTexture()
        {
            return characterSheetTexture;
        }

        public Texture2D getCharacterSilhouette()
        {
            return characterSilhouette;
        }
    }
}