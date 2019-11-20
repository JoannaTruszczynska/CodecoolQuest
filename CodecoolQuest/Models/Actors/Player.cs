namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor, IInventory
    {
        public override string TileName { get; } = "player";
        public string[] Weapons { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string[] Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Player(Cell cell) : base(cell)
        {
        }
    }
}