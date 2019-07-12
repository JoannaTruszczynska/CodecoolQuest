using Codecool.Quest.Models;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Codecool.Quest {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        GameMap map = MapLoader.LoadMap();

        // TODO: create canvas based on map size


        public MainWindow() {
            InitializeComponent();
            Launch();
        }

        public void Launch() {
            Refresh();
        }

        public void Refresh() {
            gameCanvas.Children.Clear();

            for (int x = 0; x < map.Width; x++) {
                for (int y = 0; y < map.Height; y++) {
                    Cell cell = map.GetCell(x, y);
                    if (cell.Actor != null) {
                        Tiles.DrawTile(gameCanvas, cell.Actor, x, y);
                    } else {
                        Tiles.DrawTile(gameCanvas, cell, x, y);
                    }
                }
            }
        }

        public void TestLaunch() {
            BitmapImage src = new BitmapImage();
            var img = @"pack://application:,,,/Resources/roguelikeDungeon_transparent.png";
            src.BeginInit();
            src.UriSource = new Uri(img);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();

            Image bodyImage = new Image {
                Source = new CroppedBitmap(
                    src,
                    new Int32Rect(0, 0, 16, 16)),
                Stretch = Stretch.None,
                Width = 16,
                Height = 16
            };

            gameCanvas.Children.Add(bodyImage);

        }

        private void GameCanvas_KeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Left:
                    map.Player.Move(-1, 0);
                    Refresh();
                    break;
                case Key.Up:
                    map.Player.Move(0, -1);
                    Refresh();
                    break;
                case Key.Right:
                    map.Player.Move(1, 0);
                    Refresh();
                    break;
                case Key.Down:
                    map.Player.Move(0, 1);
                    Refresh();
                    break;
            }
        }
    }
}
