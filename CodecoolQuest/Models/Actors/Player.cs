namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor
    {
        public override string TileName { get; } = "player";

        public Player(Cell cell) : base(cell)
        {
        }
    }
}