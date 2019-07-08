namespace Codecool.Quest.Models.Actors {
    public abstract class Actor : IDrawable {
        public Cell Cell { get; private set; }
        public int Health { get; set; } = 10;

        public int X { get =>   this.Cell.X; }
        public int Y { get =>   this.Cell.Y; }
        public abstract string TileName { get; }

        public Actor(Cell cell) {
            this.Cell = cell;
            this.Cell.Actor = this;
        }

        public void Move(int dx, int dy) {
            Cell nextCell = this.Cell.GetNeighbor(dx, dy);
            this.Cell.Actor = null;
            nextCell.Actor = this;
            this.Cell = nextCell;
        }
    }
}
