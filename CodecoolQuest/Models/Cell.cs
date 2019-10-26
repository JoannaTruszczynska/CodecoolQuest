using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models
{
    public class Cell : IDrawable
    {
        public Actor Actor { get; set; }
        public CellType CellType { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public string TileName => CellType.ToString("g").ToLowerInvariant();

        GameMap gameMap;

        public Cell(GameMap gameMap, int x, int y, CellType cellType)
        {
            this.gameMap = gameMap;
            X = x;
            Y = y;
            CellType = cellType;
        }

        public Cell GetNeighbor(int dx, int dy)
        {
            return gameMap.GetCell(X + dx, Y + dy);
        }
    }
}