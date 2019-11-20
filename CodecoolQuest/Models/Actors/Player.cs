namespace Codecool.Quest.Models.Actors
{
    public class Player : Actor, IInventory
    {
        public override string TileName { get; } = "player";
        public string[] Weapons { get; set; }
        public string[] Items { get; set; }

        public void GetItem()
        {

        }


        public Player(Cell cell) : base(cell)
        {
        }
    }
}