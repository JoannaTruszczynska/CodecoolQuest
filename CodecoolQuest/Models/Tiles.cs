using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Codecool.Quest.Models
{
    public static class Tiles
    {
        public const int TileWidth = 16;
        public const int DrawScale = 2;

        private static Texture2D _tileSet;
        private static IDictionary<string, Tile> _tileMap;

        public static void Load()
        {
            _tileSet = CodecoolQuestGame.GameSingleton.Content.Load<Texture2D>("roguelikeDungeon_transparent");
            _tileMap = new Dictionary<string, Tile>
            {
                {"empty", new Tile(0, 0)},
                {"wall", new Tile(1, 3)},
                {"floor", new Tile(2, 0)},
                {"player", new Tile(27, 0)},
                {"skeleton", new Tile(29, 6)}
            };

        }

        public class Tile
        {
            public Rectangle Rect;

            public Tile(int i, int j)
            {
                Rect = new Rectangle(i * (TileWidth + 1), j * (TileWidth + 1), TileWidth, TileWidth);
            }
        }

        public static void DrawTile(SpriteBatch batch, IDrawable d, int x, int y)
        {
            var tile = _tileMap[d.TileName];

            batch.Draw(
                _tileSet, 
                new Vector2(
                    x * TileWidth * DrawScale, 
                    y * TileWidth * DrawScale), 
                tile.Rect, 
                Color.White, 
                0.0f, 
                Vector2.One, 
                Vector2.One * DrawScale, 
                SpriteEffects.None, 0.0f);
        }
    }
}
