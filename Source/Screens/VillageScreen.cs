using System.Collections.Generic;
using Grimthole.MacOS.Source.Controllers;
using Grimthole.MacOS.Source.Core;
using Grimthole.MacOS.Source.NPCs;
using Grimthole.MacOS.Source.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.MacOS.Source.Screens
{
    public class VillageScreen : GameScreen 
    {
        List<Vector2> points = new List<Vector2>();
        List<Entity> npcs = new List<Entity>();
        Point tileHeightAndWidth;
        Texture2D SpriteSheet;

        List<Tile> map = new List<Tile>();
        Camera camera;

        public override void LoadContent()
        {
            base.LoadContent();

            camera = new Camera();

            //Draws the player in the middle of the region
            Player player = new Player(new Vector2(
                (ScreenManager.Instance.Dimensions.Width / 2 - ScreenManager.Instance.TileSize),
                (ScreenManager.Instance.Dimensions.Height / 2 - ScreenManager.Instance.TileSize)));

            player.LoadContent(Content);

            npcs.Add(player);

            // Constructs All NPCs then iteratively loads their content.
            Villager villager = new Villager(new Vector2(((player.pos.Left * 4) / 5), player.pos.Top));

            npcs.Add(villager);

            foreach (Entity npc in npcs)
            {
                npc.LoadContent(Content);
            }

            controller = new ExplorationController();

            Tile Floor1 = new Tile(new Rectangle(new Point(0, 0), new Point(64, 64)));
            Tile WallLt = new Tile(new Rectangle(new Point(64, 0), new Point(64, 64)));
            Tile WallRt = new Tile(new Rectangle(new Point(128, 0), new Point(64, 64)));
            Tile WallTp = new Tile(new Rectangle(new Point(192, 0), new Point(64, 64)));
            Tile WallBt = new Tile(new Rectangle(new Point(256, 0), new Point(64, 64)));
            Tile WallTL = new Tile(new Rectangle(new Point(320, 0), new Point(64, 64)));
            Tile WallTR = new Tile(new Rectangle(new Point(384, 0), new Point(64, 64)));
            Tile WallBL = new Tile(new Rectangle(new Point(448, 0), new Point(64, 64)));
            Tile WallBR = new Tile(new Rectangle(new Point(0, 64), new Point(64, 64)));
            Tile Stream = new Tile(new Rectangle(new Point(576, 0), new Point(64, 64)));

            SpriteSheet = Content.Load<Texture2D>("Backgrounds/cave2");


            // Sets the region that is drawn
            for (var i = 0; i < ScreenManager.Instance.TileSize * 40; i += ScreenManager.Instance.TileSize)
            {
                for (var j = 0; j < ScreenManager.Instance.TileSize * 60; j += ScreenManager.Instance.TileSize)
                {
                    points.Add(new Vector2(j, i));
                }
            }

            // The height and width of the tiles.
            tileHeightAndWidth = new Point(
                ScreenManager.Instance.TileSize,
                ScreenManager.Instance.TileSize
            );

            map = new List<Tile>{WallTL, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTR, WallTL, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp, WallTp,
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
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,
                                WallLt, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, Floor1,Floor1, Floor1, Floor1, Floor1, Floor1, Floor1, WallRt,

                                };


        }

        public override void Update(GameTime gameTime)
        {
            foreach (Entity npc in npcs)
            {
                controller.Update(npc, gameTime);
                npc.Update(ScreenManager.Instance.Dimensions, gameTime, Content);
            }
            camera.Follow((Player) npcs[0], ScreenManager.Instance.Dimensions);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);

            //draws each tile in the region
            int i = 0;
            foreach (Vector2 point in points)
            {
                spriteBatch.Draw(SpriteSheet, point, map[i].getSourceRectangle(), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                i++;
            }
            spriteBatch.End();

            foreach (Entity npc in npcs)
            {
                npc.Draw(spriteBatch);
            }


        }
    }
}
