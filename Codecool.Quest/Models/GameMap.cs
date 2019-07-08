using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models {
    public class GameMap {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private readonly Cell[,] cells;
        private Player Player { get; set; }

        public GameMap(int width, int height, CellType defaultCellType) {
            this.Width = width;
            this.Height = height;
            cells = new Cell[width, height];
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    cells[x, y] = new Cell(this, x, y, defaultCellType);
                }
            }
        }

        public Cell getCell(int x, int y) {
            return cells[x, y];
        }
    }
}
