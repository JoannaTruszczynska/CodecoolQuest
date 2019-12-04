using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.Quest.Models.Actors
{
    class Cow : Actor
    {
        public Cow(Cell cell) : base(cell)
        {
        }

        public override string Type { get; } = "Cow";
        public override int AttackStrength { get; set; } = 0;
        public override string TileName { get; set; } = "Cow";
    }
}
