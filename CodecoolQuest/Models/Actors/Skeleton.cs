namespace Codecool.Quest.Models.Actors
{
    public class Skeleton : Actor
    {
        public override string TileName { get; set; } = "skeleton";

        public override int AttackStrength { get; set; } = 2;

        public Skeleton(Cell cell) : base(cell)
        {
        }
    }
}