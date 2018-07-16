using Grimthole.Core;
using Grimthole.NPCs;
using Grimthole.Screens;
using Grimthole.Utils;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Grimthole.Controllers
{
	public class ExplorationController : Controller
    {
        int delta = 10; //speed at which the player moves
        TextBubble textBubble;
        Boolean talking = false;
        Boolean doneTalking = true;

        double timer;

        Array values = Enum.GetValues(typeof(Direction));

        public override void Update(Entity entity, GameTime gt, List<Entity> npcs, List<Tile> map, List<Vector2> points, TextBubble textBubble)
        {

            //checks if entity passed is player for movement checks
            if (entity.GetType() == typeof(Player))
            {
                this.textBubble = textBubble;

                if (timer > 0)
                {
                    timer -= gt.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    doneTalking = true;
                }
                UseControllerInput(entity, delta, npcs, map, points);
                UseKeyboardInputs(entity, delta, npcs, map, points);
            }
            else
            {
                int delta = (int)(gt.ElapsedGameTime.TotalMilliseconds * 0.2);
                if (((Villager)entity).npcTimer > 0)
                {
                    Console.WriteLine(((Villager)entity).Direction);
                    ((Villager)entity).npcTimer -= gt.ElapsedGameTime.TotalSeconds;
                    switch (((Villager)entity).Direction)
                    {
                        case Direction.Up:
                            //if (CheckUpCollision(sprites[0].SpriteDimensions))
                            // {
                            MoveCommand.MoveUp(entity, delta);
                            // }
                            break;
                        case Direction.Down:
                            // if (CheckBottomCollision(sprites[0].SpriteDimensions))
                            //{
                            MoveCommand.MoveDown(entity, delta);
                            //}
                            break;
                        case Direction.Left:
                            //if (CheckLeftCollision(sprites[0].SpriteDimensions))
                            //{
                            MoveCommand.MoveLeft(entity, delta);
                            //}
                            break;
                        case Direction.Right:
                            // if (CheckRightCollision(sprites[0].SpriteDimensions))
                            //{
                            MoveCommand.MoveRight(entity, delta);
                            // }
                            break;

                    }

                }
                else
                {
                    if (((Villager)entity).waitTime > 0)
                    {
                        ((Villager)entity).waitTime -= gt.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        ((Villager)entity).npcTimer = 1;
                        Random random = new Random();
                        ((Villager)entity).Direction = (Direction)values.GetValue(random.Next(values.Length));
                        Random rnd = new Random();
                        double number = rnd.Next(0, 2);
                        ((Villager)entity).waitTime = number;
                    }
                }
            }
            

        }

        public override void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if (talking)
            {
                textBubble.Draw(spriteBatch, camera);
            }
        }

        //checks if player is next to another npc for when the action key gets pressed
        int CheckSpriteCollision(Entity player, List<Entity> npcs, List<Tile> map)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                if (player.SpritePosition.Left < npcs[i].SpritePosition.Right && player.SpritePosition.Top < npcs[i].SpritePosition.Bottom && player.SpritePosition.Right > npcs[i].SpritePosition.Left && player.SpritePosition.Bottom > npcs[i].SpritePosition.Top)
                {
                    if (player.SpritePosition.Y > npcs[i].SpritePosition.Y - 32 && player.SpritePosition.Bottom < npcs[i].SpritePosition.Bottom + 32)
                    {
                        return i;
                    }
                }
            }
            return 999999999;
        }

        //checks if there is a collisions to entities left
        Boolean CheckLeftCollision(Entity player, List<Entity> npcs, List<Tile> map, List<Vector2> points)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                if (player.SpritePosition.Left < npcs[i].SpritePosition.Right && player.SpritePosition.Top < npcs[i].SpritePosition.Bottom - delta && player.SpritePosition.Right > npcs[i].SpritePosition.Left && player.SpritePosition.Bottom > npcs[i].SpritePosition.Top + delta)
                {
                    if (player.SpritePosition.Left > npcs[i].SpritePosition.Left)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < map.Count; i++)
            {
                if (map[i].GetTileTypes().Equals(Tile.TileTypes.Collidable))
                {
                    if (player.SpritePosition.Left < points[i].X + ScreenManager.Instance.TileSize && player.SpritePosition.Top < points[i].Y + ScreenManager.Instance.TileSize && player.SpritePosition.Right > points[i].X && player.SpritePosition.Bottom > points[i].Y + delta)
                    {
                        if (player.SpritePosition.Left > points[i].X)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //checks if there is a collisions to entities right
        Boolean CheckRightCollision(Entity player, List<Entity> npcs, List<Tile> map, List<Vector2> points)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                if (player.SpritePosition.Left < npcs[i].SpritePosition.Right && player.SpritePosition.Top < npcs[i].SpritePosition.Bottom - delta && player.SpritePosition.Right > npcs[i].SpritePosition.Left && player.SpritePosition.Bottom > npcs[i].SpritePosition.Top + delta)
                {
                    if (player.SpritePosition.Right < npcs[i].SpritePosition.Right)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < map.Count; i++)
            {
                if (map[i].GetTileTypes().Equals(Tile.TileTypes.Collidable))
                {
                    if (player.SpritePosition.Left < points[i].X + ScreenManager.Instance.TileSize && player.SpritePosition.Top < points[i].Y + ScreenManager.Instance.TileSize - delta && player.SpritePosition.Right > points[i].X && player.SpritePosition.Bottom > points[i].Y + delta)
                    {
                        if (player.SpritePosition.Right < points[i].X + ScreenManager.Instance.TileSize)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        //checks if there is a collisions above the entity
        Boolean CheckUpCollision(Entity player, List<Entity> npcs, List<Tile> map, List<Vector2> points)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                if (player.SpritePosition.Left < npcs[i].SpritePosition.Right - delta && player.SpritePosition.Top < npcs[i].SpritePosition.Bottom + delta && player.SpritePosition.Right > npcs[i].SpritePosition.Left + delta && player.SpritePosition.Bottom > npcs[i].SpritePosition.Top)
                {
                    if (player.SpritePosition.Top > npcs[i].SpritePosition.Top)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < map.Count; i++)
            {
                if (map[i].GetTileTypes().Equals(Tile.TileTypes.Collidable))
                {
                    if (player.SpritePosition.Left + delta < points[i].X + ScreenManager.Instance.TileSize && player.SpritePosition.Top < points[i].Y + ScreenManager.Instance.TileSize + delta && player.SpritePosition.Right > points[i].X + delta && player.SpritePosition.Bottom > points[i].Y)
                    {
                        if (player.SpritePosition.Top > points[i].Y)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        //checks if there is a collisions below the entity
        Boolean CheckBottomCollision(Entity player, List<Entity> npcs, List<Tile> map, List<Vector2> points)
        {
            for (int i = 0; i < npcs.Count; i++)
            {
                if (player.SpritePosition.Left < npcs[i].SpritePosition.Right - delta && player.SpritePosition.Top < npcs[i].SpritePosition.Bottom && player.SpritePosition.Right > npcs[i].SpritePosition.Left + delta && player.SpritePosition.Bottom > npcs[i].SpritePosition.Top)
                {
                    if (player.SpritePosition.Bottom < npcs[i].SpritePosition.Bottom)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < map.Count; i++)
            {
                if (map[i].GetTileTypes().Equals(Tile.TileTypes.Collidable))
                {
                    if (player.SpritePosition.Left < points[i].X + ScreenManager.Instance.TileSize - delta && player.SpritePosition.Top < points[i].Y + ScreenManager.Instance.TileSize && player.SpritePosition.Right > points[i].X + delta && player.SpritePosition.Bottom > points[i].Y)
                    {
                        if (player.SpritePosition.Bottom < points[i].Y + ScreenManager.Instance.TileSize)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
       

        void UseControllerInput(Entity entity, int delta, List<Entity> npcs, List<Tile> map, List<Vector2> points)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            // Get the current state of Controller1
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            if (capabilities.IsConnected && capabilities.HasLeftXThumbStick)
            {
                if (state.ThumbSticks.Left.X < -0.5f)
                {
                    MoveCommand.MoveLeft(entity, delta);
                }

                if (state.ThumbSticks.Left.X > 0.5f)
                {
                    MoveCommand.MoveRight(entity, delta);
                }

                if (state.ThumbSticks.Left.Y > 0.5f)
                {
                    MoveCommand.MoveDown(entity, delta);
                }

                if (state.ThumbSticks.Left.Y < -0.5f)
                {
                    MoveCommand.MoveUp(entity, delta);
                }
            }
        }

        void UseKeyboardInputs(Entity entity, int delta, List<Entity> npcs, List<Tile> map, List<Vector2> points)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && CheckRightCollision(entity, npcs, map, points) && !talking)
            {
                MoveCommand.MoveRight(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) && CheckLeftCollision(entity, npcs, map, points) && !talking)
            {
                MoveCommand.MoveLeft(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) && CheckUpCollision(entity, npcs, map, points) && !talking)
            {
                MoveCommand.MoveUp(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) && CheckBottomCollision(entity, npcs, map, points) && !talking)
            {
                MoveCommand.MoveDown(entity, delta);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.J) && CheckSpriteCollision(entity, npcs, map) != 999999999)
            {
                if (!talking && doneTalking)
                {
                    doneTalking = false;
                    timer = 0.5;
                    int index = CheckSpriteCollision(entity, npcs, map);
                    textBubble.Text = ((Villager)npcs[index]).Response;
                    textBubble.SpritePosition = new Rectangle(npcs[index].SpritePosition.X - 64, npcs[index].SpritePosition.Y - 64, 128, 64);
                    talking = true;
                }
                else if(doneTalking)
                {
                    doneTalking = false;
                    talking = false;
                    timer = 0.5;
                }


            }
        }
    }
}
