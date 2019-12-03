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
    public class Door : Thing
    {
        public Door(Cell cell, List<string> allowKeys) : base(cell)
        {
            _allowKeys = allowKeys;
            cell.CanIMoveHere = false;
        }

        private List<string> _allowKeys { get;}
        public void KeyLock(List<Key> playerKeys)// todo keylock not work correctly !!!
        {
            var allowKeys = new List<string>(_allowKeys);
            foreach (var key in playerKeys)
            {
                playerKeys.ForEach(x => Console.WriteLine(x.Name));
                if (allowKeys.Contains(key.Name))
                {
                    this.Cell.CanIMoveHere = true;
                }
            }
            
        }

        public override string TileName { get; } = "door";
        public override string Type { get; } = "door";
        public override string Subtype { get; } = "door";

        public override void UpdateOwnerProperties(Actor actor)
        {
        }
    }
}