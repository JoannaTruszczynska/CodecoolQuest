using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models.Actors

{
    public class Player : Actor
    {
        public Player(Cell cell) : base(cell)
        {
        }

        public override string Type { get; } = "player";
        public override int AttackStrength { get; set; } = 5;
        public override string TileName { get; set; } = "player";

        public Thing Weapon { get; set; }
        
        private List<Thing> _items = new List<Thing>();

        public int SightRange { get; set; } = 4;

        public List<Thing> GetItems()
        {
            return _items;

        }
        public void SetItem(Thing thing)
        {
            _items.Add(thing);
        }
    }
}