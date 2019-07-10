using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Codecool.Quest.Models {
    public static class Tiles {
        public static int TILE_WIDTH = 16;
        private static BitmapImage tileSet = new BitmapImage();
        private static IDictionary<string, Tile> tileMap = new Dictionary<string, Tile>();

        static Tiles() {
            var img = @"pack://application:,,,/Resources/roguelikeDungeon_transparent.png";
            tileSet.BeginInit();
            tileSet.UriSource = new Uri(img);
            tileSet.CacheOption = BitmapCacheOption.OnLoad;
            tileSet.EndInit();

            tileMap.Add("empty", new Tile(0, 0));
            tileMap.Add("wall", new Tile(1, 3));
            tileMap.Add("floor", new Tile(2, 0));
            tileMap.Add("player", new Tile(27, 0));
            tileMap.Add("skeleton", new Tile(29, 6));
        }

        public class Tile {
            public int x, y, w, h;
            public Tile(int i, int j) {
                x = i * (TILE_WIDTH + 2);
                y = j * (TILE_WIDTH + 2);
                w = TILE_WIDTH;
                h = TILE_WIDTH;
            }
        }

        public static void drawTile(Canvas context, IDrawable d, int x, int y) {
            Tile tile = tileMap[d.TileName];

            var bodyImage = new Image {
                Source = new CroppedBitmap(
                    tileSet,
                    new Int32Rect(tile.x, tile.y, tile.w, tile.h)),
                Stretch = Stretch.None,
                Width = TILE_WIDTH,
                Height = TILE_WIDTH
            };

            context.Children.Add(bodyImage);
        }
    }
}
