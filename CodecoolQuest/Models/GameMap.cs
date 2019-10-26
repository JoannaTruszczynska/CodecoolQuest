using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class GameMap
    {
        public int Height { get; }
        public int Width { get; }
        private readonly Cell[,] cells;
        public Player Player { get; set; }

        public GameMap(int width, int height, CellType defaultCellType)
        {
            Width = width;
            Height = height;
            cells = new Cell[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(this, x, y, defaultCellType);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return cells[x, y];
        }
    }
}