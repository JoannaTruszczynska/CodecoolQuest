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

            tileMap.Add("empty", new Tile(8, 7));
            tileMap.Add("wall", new Tile(8, 2));
            tileMap.Add("floor", new Tile(6, 11));
            tileMap.Add("player", new Tile(15, 17));
            tileMap.Add("skeleton", new Tile(3, 2));
        }

        public class Tile {
            public int x, y, w, h;
            public Tile(int i, int j) {
                x = i * (TILE_WIDTH + 1);
                y = j * (TILE_WIDTH + 1);
                w = TILE_WIDTH;
                h = TILE_WIDTH;
            }
        }

        public static void DrawTile(Canvas context, IDrawable d, int x, int y) {
            Tile tile = tileMap[d.TileName];

            var bodyImage = new Image {
                Source = new CroppedBitmap(
                    tileSet,
                    new Int32Rect(tile.x, tile.y, tile.w, tile.h)),
                Stretch = Stretch.None,
                Width = TILE_WIDTH,
                Height = TILE_WIDTH,
            };

            bodyImage.SetValue(Canvas.LeftProperty, ((double)x * TILE_WIDTH));
            bodyImage.SetValue(Canvas.TopProperty, ((double)y * TILE_WIDTH));

            context.Children.Add(bodyImage);
        }
    }
}
