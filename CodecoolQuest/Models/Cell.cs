using System;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models
{
    public class Cell : IDrawable
    {
        public Actor Actor { get; set; }
        public Thing Thing { get; set; }
        public CellType CellType { get; set; }

        public bool CanIMoveHere { get; set; }
        public bool CanIFight { get; set; }
        public int X { get; }
        public int Y { get; }

        public string TileName => CellType.ToString("g").ToLowerInvariant();


        private readonly GameMap _gameMap;

        public Cell(GameMap gameMap, int x, int y, CellType cellType)
        {
            _gameMap = gameMap;
            X = x;
            Y = y;
            CellType = cellType;
        }

        public Cell GetNeighbor(int dx, int dy)
        {
            return _gameMap.GetCell(X + dx, Y + dy) ?? this;
        }
    }
}