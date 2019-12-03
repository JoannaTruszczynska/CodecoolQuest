using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models.Things
{
    public class Key : Thing
    {

        public Key(Cell cell, string keyName, string tileName) : base(cell)
        {
            TileName = tileName;
            Name = keyName;
        }

        public string Name { get; }
        public override string TileName { get; }
        public override string Type { get; } = "item";
        public override string Subtype { get; } = "key";

        public override void UpdateOwnerProperties(Actor actor)
        {
            var player = (Player) actor;
            player.SetItem(this);
        }
    }
}