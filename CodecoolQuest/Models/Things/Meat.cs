using System;
using System.Collections.Generic;
using System.Text;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Things
{
    class Meat : Thing
    {
        public Meat(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "meat";
        public override string Type { get; } = "meat";
        public override string Subtype { get; }
        public override void UpdateOwnerProperties(Actor actor)
        {
            actor.Health += 5;
        }
    }
}
