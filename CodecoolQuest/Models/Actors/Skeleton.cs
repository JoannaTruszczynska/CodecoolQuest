namespace Codecool.Quest.Models.Actors
{
    public class Skeleton : Actor
    {
        public override string TileName { get; } = "skeleton";

        public Skeleton(Cell cell) : base(cell)
        {
        }
    }
}