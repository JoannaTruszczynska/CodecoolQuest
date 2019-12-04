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

        public override string Type { get; } = "cow";
        public override int AttackStrength { get; set; } = 0;
        public override string TileName { get; set; } = "cow";

        public override void Move(int dx, int dy)
        {
            //doesn't move
        }
    }
}
