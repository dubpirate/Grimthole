using System.Collections.Generic;
using Grimthole.Controllers;
using Grimthole.Core;
using Grimthole.NPCs;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Screens
{
    public class VillageScreen : GameScreen 
    {
        List<Vector2> points = new List<Vector2>();
        List<Entity> npcs = new List<Entity>();
        Point tileHeightAndWidth;
        Texture2D SpriteSheet;
        Player player;
        int width = 60;
        int height = 40;
        TextBubble textBubble;

        Tile Floor1;
        Tile RoadSd;
        Tile RoadFk;
        Tile RoadUp;
        Tile Hou1p1;
        Tile Hou1p2;
        Tile Hou1p3;
        Tile Hou1p4;
        Tile Hou1p5;
        Tile Hou1p6;
        Tile WallLt; //Left Wall
        Tile WallRt; // Right Wall
        Tile WallTp; //Top Wall
        Tile WallBt; //Bottom Wall
        Tile WallTL; //TopLeft Wall
        Tile WallTR; //TopRight Wall
        Tile WallBL; //BottomLeft Wall
        Tile WallBR; //BottomRight Wall
        Tile Stream;

        List<Tile> map = new List<Tile>();
        Camera camera;

        public override void LoadContent()
        {
            base.LoadContent();

            camera = new Camera();

            //Draws the player in the middle of the region
            player = new Player(new Vector2(1000, 1000));
            
            textBubble = new TextBubble("pussy", new Vector2(500, 500));

            player.LoadContent(Content);

            textBubble.LoadContent(Content);

            // Constructs All NPCs then iteratively loads their content.
            Villager villager = new Villager(new Vector2(500,700));
            villager.Response = "I hate eating ass";
            Villager villager2 = new Villager(new Vector2(900, 900));
            villager2.Response = "I love eating ass";
            Villager villager3 = new Villager(new Vector2(1050, 400));
            villager3.Response = "Where am I?";
            Villager villager4 = new Villager(new Vector2(1050, 700));
            villager4.Response = "Call me Mr Ass";
            npcs.Add(villager);
            npcs.Add(villager2);
            npcs.Add(villager3);
            npcs.Add(villager4);

            foreach (Entity npc in npcs)
            {
                npc.LoadContent(Content);
            }

            controller = new ExplorationController();

            //sets each tile images from the sprite sheet into their own variables
            Floor1 = new Tile(new Rectangle(new Point(0, 0), new Point(32, 32)));
            Stream = new Tile(new Rectangle(new Point(0, 32), new Point(32, 32)), Tile.TileTypes.Collidable);
            RoadSd = new Tile(new Rectangle(new Point(32, 0), new Point(32, 32)));
            RoadUp = new Tile(new Rectangle(new Point(64, 32), new Point(32, 32)));
            RoadFk = new Tile(new Rectangle(new Point(64, 0), new Point(32, 32)));
            Hou1p1 = new Tile(new Rectangle(new Point(96, 0), new Point(32, 32)), Tile.TileTypes.Collidable);
            Hou1p2 = new Tile(new Rectangle(new Point(128, 0), new Point(32, 32)), Tile.TileTypes.Collidable);
            Hou1p3 = new Tile(new Rectangle(new Point(162, 0), new Point(32, 32)), Tile.TileTypes.Collidable);
            Hou1p4 = new Tile(new Rectangle(new Point(96, 32), new Point(32, 32)), Tile.TileTypes.Collidable);
            Hou1p5 = new Tile(new Rectangle(new Point(128, 32), new Point(32, 32)), Tile.TileTypes.Collidable);
            Hou1p6 = new Tile(new Rectangle(new Point(162, 32), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallBL = new Tile(new Rectangle(new Point(32, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallBR = new Tile(new Rectangle(new Point(64, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallLt = new Tile(new Rectangle(new Point(96, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallRt = new Tile(new Rectangle(new Point(128, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallTL = new Tile(new Rectangle(new Point(160, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallTR = new Tile(new Rectangle(new Point(192, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallTp = new Tile(new Rectangle(new Point(0, 64), new Point(32, 32)), Tile.TileTypes.Collidable);
            WallBt = new Tile(new Rectangle(new Point(224, 64), new Point(32, 32)), Tile.TileTypes.Collidable);


            /*
            Floor1 = new Tile(new Rectangle(new Point(0, 0), new Point(64, 64)));
            Stream = new Tile(new Rectangle(new Point(0, 64), new Point(64, 64)));
            RoadSd = new Tile(new Rectangle(new Point(64, 0), new Point(64, 64)));
            RoadUp = new Tile(new Rectangle(new Point(128, 64), new Point(64, 64)));
            RoadFk = new Tile(new Rectangle(new Point(128, 0), new Point(64, 64)));
            House = new Tile(new Rectangle(new Point(128, 0), new Point(64, 64)));
            WallBL = new Tile(new Rectangle(new Point(64, 128), new Point(64, 64)));
            WallBR = new Tile(new Rectangle(new Point(128, 128), new Point(64, 64)));
            WallLt = new Tile(new Rectangle(new Point(192, 128), new Point(64, 64)));
            WallRt = new Tile(new Rectangle(new Point(256, 128), new Point(64, 64)));
            WallTL = new Tile(new Rectangle(new Point(320, 128), new Point(64, 64)));
            WallTR = new Tile(new Rectangle(new Point(384, 128), new Point(64, 64)));
            WallTp = new Tile(new Rectangle(new Point(0, 128), new Point(64, 64)));
            WallBt = new Tile(new Rectangle(new Point(448, 128), new Point(64, 64)));
            */
            SpriteSheet = Content.Load<Texture2D>("Backgrounds/cave3");


            // Sets the region that is drawn
            for (var i = 0; i < ScreenManager.Instance.TileSize * height; i += ScreenManager.Instance.TileSize)
            {
                for (var j = 0; j < ScreenManager.Instance.TileSize * width; j += ScreenManager.Instance.TileSize)
                {
                    points.Add(new Vector2(j, i));
                }
            }

            // The height and width of the tiles.
            tileHeightAndWidth = new Point(
                ScreenManager.Instance.TileSize,
                ScreenManager.Instance.TileSize
            );
            map = new List<Tile>{WallTL, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTR,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Hou1p1, Hou1p2, Hou1p3, Floor1, Floor1, Floor1, RoadUp, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,WallRt,
                                WallLt, Floor1, Hou1p4, Hou1p5, Hou1p6, Floor1, Floor1, Floor1, RoadUp, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, RoadUp, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, RoadUp, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, RoadUp, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, RoadSd, RoadSd, RoadSd, RoadSd, RoadSd, RoadSd, RoadSd, RoadFk, RoadSd, RoadSd, RoadSd, RoadSd, RoadSd, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                Stream, Stream, Stream, Stream, Stream, Floor1, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream,Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream, Stream,Stream, Stream, Stream, Stream, Stream, Stream, Stream,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallBL, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallBR

                                };

        }

        public override void Update(GameTime gameTime)
        {
            //updates each npc on the curent screen
            foreach (Entity npc in npcs)
            {
                npc.Update(ScreenManager.Instance.Dimensions, gameTime, Content);
            }
            controller.Update(player, gameTime, npcs, map, points, textBubble);

            player.Update(ScreenManager.Instance.Dimensions, gameTime, Content);
            camera.Follow(player, width, height);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(transformMatrix:camera.Transform);

            //draws each tile in the region
            int i = 0;
            foreach (Vector2 point in points)
            {
                spriteBatch.Draw(SpriteSheet, point, map[i].getSourceRectangle(), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
                i++;
            }
            
            spriteBatch.End();
            foreach (Entity npc in npcs)
            {
                npc.Draw(spriteBatch, camera);
            }

            player.Draw(spriteBatch, camera);
            
            controller.Draw(spriteBatch, camera);
        }
    }
}
