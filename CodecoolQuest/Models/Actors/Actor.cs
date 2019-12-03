namespace Codecool.Quest.Models.Actors
{
    public abstract class Actor : IDrawable
    {
        public Cell Cell { get; private set; }
        public int Health { get; set; } = 10;
        public abstract int AttackStrength { get; set; }

        public bool InFightCantMove { get; set; } = false;
        public int X => Cell.X;

        public int Y => Cell.Y;

        public abstract string TileName { get; set; }

        protected Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }

        public void Move(int dx, int dy)
        {
            var nextCell = Cell.GetNeighbor(dx, dy);
            Cell.Actor = null;
            nextCell.Actor = this;

            nextCell.CanIMoveHere = false;
            Cell.CanIMoveHere = true;
            nextCell.CanIFight = true;
            Cell.CanIFight = false;
            Cell = nextCell;
        }

        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
        }

        public void Fight(Cell neighbourCell, GameMap _map)

        {
            neighbourCell.Actor.TakeDamage(this.AttackStrength);
            

            if (neighbourCell.Actor.Health > 0)
            {
                neighbourCell.Actor.InFightCantMove = true;
                this.TakeDamage(neighbourCell.Actor.AttackStrength);
            }
            else
            {
                
                neighbourCell.Actor = null;
                neighbourCell.CanIFight = false;
                neighbourCell.CanIMoveHere = true;
                neighbourCell.CellType = CellType.Floor;
            }
        }
    }
}