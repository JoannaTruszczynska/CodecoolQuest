﻿using System;
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
        public Door(Cell cell, List<string> allowKeys,  CodecoolQuestGame main, string subtype = "door")
            : base(cell)
        {
            _allowKeys = allowKeys;
            cell.CanIMoveHere = false;
            Subtype = subtype;
            Main = main;
        }

        private CodecoolQuestGame Main { get; }
        
        private List<string> _allowKeys { get;}
        public void KeyLock(List<Key> playerKeys)// todo keylock not work correctly !!!
        {
            var allowKeys = new List<string>(_allowKeys);
            foreach (var key in playerKeys)
            {
                if (allowKeys.Contains(key.Name))
                {
                    this.Cell.CanIMoveHere = true;
                    Main._endMap.Player.TileName = Main._map.Player.TileName;
                    Main._map = Main._endMap;
                    
                }
            }
        }

        public override string TileName { get; } = "door";
        public override string Type { get; } = "door";
        public override string Subtype { get; }

        public override void UpdateOwnerProperties(Actor actor)
        {
            if (Subtype == "exitDoor")
            {
                Main.ExitGame = true;
            }
        }
    }
}