﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest.Models.Things
{
    public class Key : Item
    {

        public Key(Cell cell) : base(cell)
        {
        }

        public override string TileName { get; } = "key";
    }
}