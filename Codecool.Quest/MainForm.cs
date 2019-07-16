using Codecool.Quest.Models;
using System.Drawing;
using System.Windows.Forms;

namespace Codecool.Quest {
    public partial class MainForm : Form {
        GameMap map = MapLoader.LoadMap();

        public MainForm() {
            InitializeComponent();
            Launch();
        }

        public void Launch() {
            Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Left:
                    map.Player.Move(-1, 0);
                    Refresh();
                    break;
                case Keys.Up:
                    map.Player.Move(0, -1);
                    Refresh();
                    break;
                case Keys.Right:
                    map.Player.Move(1, 0);
                    Refresh();
                    break;
                case Keys.Down:
                    map.Player.Move(0, 1);
                    Refresh();
                    break;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.Black);

            for (int x = 0; x < map.Width; x++) {
                for (int y = 0; y < map.Height; y++) {
                    Cell cell = map.GetCell(x, y);
                    if (cell.Actor != null) {
                        Tiles.DrawTile(e.Graphics, cell.Actor, x, y);
                    }
                    else {
                        Tiles.DrawTile(e.Graphics, cell, x, y);
                    }
                }
            }
        }
    }
}
