using System;
using System.Collections.Generic;
using System.Text;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Things
{
    class Ghost: Skeleton
    {
        public Ghost(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; set; } = "ghost";

        public override string Type { get; } = "skeleton";
        public override int AttackStrength { get; set; } = 1;
    }
}
