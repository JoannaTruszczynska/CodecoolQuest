using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models.Things
{
    public class Heart : Thing
    {

        public Heart(Cell cell) : base(cell)
        {
        }

        public int ExtraHealth { get; } = 5;
        public override string TileName { get; } = "heart";
        public override string Type { get; } = "item";
        public override string Subtype { get; } = "life";

        public override void UpdateOwnerProperties(Actor actor)
        {
            actor.Health += ExtraHealth;
        }
    }
}