using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models.Things
{
    public class Door : Item
    {
        public Door(Cell cell, int needMatchedKeys) : base(cell)
        {
            NeedMatchedKeys = needMatchedKeys;
            cell.CanIMoveHere = false;
        }
        
        private int NeedMatchedKeys { get; }
        public void KeyLock(List<Key> keys)
        {
            int matchedKeys = 0;
            string allowKey = "blueKey";

            foreach (var key in keys)
            {
                if (key.Name == allowKey)
                {
                    matchedKeys++;
                }

                if (matchedKeys == NeedMatchedKeys)
                {
                    this.Cell.CanIMoveHere = true;
                }
            }
        }

        public override string TileName { get; } = "door";
        public override string Type { get; } = "door";
    }
}