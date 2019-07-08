using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models {
    public class Cell {
        public Actor Actor { get; set; }
        public CellType CellType { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        GameMap gameMap;

        public Cell(GameMap gameMap, int x, int y, CellType cellType) {
            this.gameMap = gameMap;
            this.X = x;
            this.Y = y;
            this.CellType = cellType;
        }

        public Cell GetNeighbor(int dx, int dy) {
            return gameMap.getCell(X + dx, Y + dy);
        }

        public string GetTileName() {
            return CellType.ToString("g").ToLowerInvariant();
        }
    }
}
