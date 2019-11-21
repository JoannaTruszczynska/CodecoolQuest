using System.Collections.Generic;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models.Actors

{
    public class Player : Actor
    {
        public Player(Cell cell) : base(cell)
        {
        }

        public override int AttackStrength { get; set; } = 5;
        public override string TileName { get; } = "player";
        public Item Weapon { get; set; }
        
        private List<Item> _items = new List<Item>();

        public List<Item> GetItems()
        {
            return _items;

        }

        public void SetItem(Item item)
        {
            _items.Add(item);
        }
        
    }
}