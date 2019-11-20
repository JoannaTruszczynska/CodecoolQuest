using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest.Models;

namespace Codecool.Quest.Models.Things
{
    public abstract class Thing : IDrawable
    {
        protected Thing(Cell cell)
        {
            Cell = cell;
            Cell.Thing = this;

        }
        public Cell Cell { get; private set; }

        public abstract string TileName { get; }
    }
}