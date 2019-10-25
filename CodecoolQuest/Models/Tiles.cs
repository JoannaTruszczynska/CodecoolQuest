using System.Collections.Generic;
using CodecoolQuest;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Codecool.Quest.Models
{
    public static class Tiles
    {
        public const int TILE_WIDTH = 16;
        public const int DRAW_SCALE = 2;

        private static Texture2D _tileSet;
        private static IDictionary<string, Tile> _tileMap;

        public static void Load()
        {
            _tileSet = CodecoolQuestGame.GameSingleton.Content.Load<Texture2D>("roguelikeDungeon_transparent");
            _tileMap = new Dictionary<string, Tile>();

            _tileMap.Add("empty", new Tile(0, 0));
            _tileMap.Add("wall", new Tile(1, 3));
            _tileMap.Add("floor", new Tile(2, 0));
            _tileMap.Add("player", new Tile(27, 0));
            _tileMap.Add("skeleton", new Tile(29, 6));
        }

        public class Tile
        {
            public Rectangle Rect;

            public Tile(int i, int j)
            {
                Rect = new Rectangle(i * (TILE_WIDTH + 1), j * (TILE_WIDTH + 1), TILE_WIDTH, TILE_WIDTH);
            }
        }

        public static void DrawTile(SpriteBatch batch, IDrawable d, int x, int y)
        {
            Tile tile = _tileMap[d.TileName];

            batch.Draw(_tileSet, new Vector2(x * TILE_WIDTH * DRAW_SCALE, y * TILE_WIDTH * DRAW_SCALE), tile.Rect, Color.White, 0.0f, Vector2.One, Vector2.One * DRAW_SCALE, SpriteEffects.None, 0.0f);
        }
    }
}
