using System.Collections.Generic;
using System.Drawing;

namespace Codecool.Quest.Models {
    public static class Tiles {
        public const int TILE_WIDTH = 16;
        public const int DRAW_SCALE = 2;

        private static Bitmap tileSet;
        private static IDictionary<string, Tile> tileMap;

        static Tiles() {
            tileSet = new Bitmap("Resources/roguelikeDungeon_transparent.png");
            tileMap = new Dictionary<string, Tile>();

            tileMap.Add("empty", new Tile(0, 0));
            tileMap.Add("wall", new Tile(1, 3));
            tileMap.Add("floor", new Tile(2, 0));
            tileMap.Add("player", new Tile(27, 0));
            tileMap.Add("skeleton", new Tile(29, 6));
        }

        public class Tile {
            public int x, y, w, h;
            public Bitmap bitmap;
            public Tile(int i, int j) {
                x = i * (TILE_WIDTH + 1);
                y = j * (TILE_WIDTH + 1);
                w = TILE_WIDTH;
                h = TILE_WIDTH;
                bitmap = tileSet.Clone(new Rectangle(x, y, w, h), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
        }

        public static void DrawTile(Graphics graphics, IDrawable d, int x, int y) {
            Tile tile = tileMap[d.TileName];

            graphics.DrawImage(tile.bitmap, x * TILE_WIDTH * DRAW_SCALE, y * TILE_WIDTH * DRAW_SCALE, tile.w * DRAW_SCALE, tile.h * DRAW_SCALE);
        }
    }
}
