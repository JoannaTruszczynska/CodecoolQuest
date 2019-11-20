using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest;
using Codecool.Quest.Models;

namespace Codecool.Quest.Models.Things
{
    public class Sword : Thing
    {
        public Sword(Cell cell) : base(cell)
        {
        }
        public override string TileName { get; } = "weapon";


    }
}