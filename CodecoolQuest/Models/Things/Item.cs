using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models.Things
{
    public abstract class Item : IDrawable
    {
        protected Item(Cell cell)
        {
            Cell = cell;
            Cell.Item = this;
        }

        public Cell Cell { get; private set; }
        public abstract string TileName { get; }
        public abstract string Type { get; }

        public void Disable()
        {
            Cell.Item = null;
        }
    }
}
