using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Things
{
    /// <summary>
    /// This abstract class is the basis for things on the map
    /// </summary>
    public abstract class Thing : IDrawable
    {
        protected Thing(Cell cell)
        {
            Cell = cell;
            Cell.Thing = this;
        }

        public Cell Cell { get; private set; }
        public abstract string TileName { get; }
        public abstract string Type { get; }
        public abstract string Subtype { get; }
        public abstract void UpdateOwnerProperties(Actor actor);
        
        /// <summary>
        /// This method removes the sprite's visibility from the map (it does not delete the object!!!)
        /// </summary>
        public void Disable()
        {
            Cell.Thing = null;
        }
    }
}