using System;
using System.Collections.Generic;
using Grimthole.Controllers;
using Grimthole.Core;
using Grimthole.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grimthole.Screens
{
    public class VillageScreen : GameScreen 
    {
        List<Vector2> points = new List<Vector2>();
		Point tileHeightAndWidth;
        Player player;
        Texture2D SpriteSheet;
        Tile Floor1;
        Tile WallLt;
        Tile WallRt;
        Tile WallTp;
        Tile WallBt;
        Tile WallTL;
        Tile WallTR;
        Tile WallBL;
        Tile WallBR;
        Tile Stream;
        List<Tile> map = new List<Tile>();

        public override void LoadContent()
        {
            base.LoadContent();
            SpriteSheet = Content.Load<Texture2D>("cave2");
            Floor1 = new Tile(new Rectangle(new Point(0,0), new Point(64, 64)));
            Stream = new Tile(new Rectangle(new Point(64, 0), new Point(64, 64)));
            WallBL = new Tile(new Rectangle(new Point(128, 0), new Point(64, 64)));
            WallBR = new Tile(new Rectangle(new Point(192, 0), new Point(64, 64)));
            WallLt = new Tile(new Rectangle(new Point(256, 0), new Point(64, 64)));
            WallRt = new Tile(new Rectangle(new Point(320, 0), new Point(64, 64)));
            WallTL = new Tile(new Rectangle(new Point(384, 0), new Point(64, 64)));
            WallTR = new Tile(new Rectangle(new Point(448, 0), new Point(64, 64)));
            WallTp = new Tile(new Rectangle(new Point(0, 64), new Point(64, 64)));
            WallBt = new Tile(new Rectangle(new Point(576, 0), new Point(64, 64)));
            controller = new ExplorationController();

			//Draws the player in the middle of the region
			player = new Player( new Vector2(
				(ScreenManager.Instance.Dimensions.Width / 2 - ScreenManager.Instance.TileSize), 
				(ScreenManager.Instance.Dimensions.Height / 2 - ScreenManager.Instance.TileSize)));

            player.LoadContent(Content);

            //sets the region that is drawn
            for (var i = 0; i < ScreenManager.Instance.TileSize*40; i += ScreenManager.Instance.TileSize)
            {
                for (var j = 0; j < ScreenManager.Instance.TileSize*60; j += ScreenManager.Instance.TileSize)
                {
                    points.Add(new Vector2(j, i));
                    //map.Add(Floor1);
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
			controller.Update(player, gameTime);
            player.Update(ScreenManager.Instance.Dimensions, gameTime, Content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //draws each tile in the region
            int i = 0;
            foreach (Vector2 point in points)
            {
                spriteBatch.Draw(SpriteSheet, point,map[i].getSourceRectangle(), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
                i++;
            }
            spriteBatch.End();

            player.Draw(spriteBatch);
        }
    }
}