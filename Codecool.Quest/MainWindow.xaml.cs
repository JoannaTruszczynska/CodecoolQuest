using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Codecool.Quest {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Launch();
        }

        public void Launch() {
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
    }
}
