using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest;
using Codecool.Quest.Models;

namespace Codecool.Quest.Models.Things
{
    public class Sword : Item
    {
        public Sword(Cell cell) : base(cell)
        {
        }
        public override string TileName { get; } = "sword";
        public override string Type { get; } = "weapon";
    }
}