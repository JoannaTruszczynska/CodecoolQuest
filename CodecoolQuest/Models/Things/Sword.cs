using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codecool.Quest;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Things
{
    public class Sword : Thing
    {
        public Sword(Cell cell) : base(cell)
        {
        }

        public int ExtraDamage { get;} = 3;
        public override string TileName { get; } = "sword";
        public override string Type { get; } = "weapon";
        public override string Subtype { get; } = "sword";

        public override void UpdateOwnerProperties(Actor actor)
        {
            var player = (Player) actor;
            player.AttackStrength += ExtraDamage;
        }
    }
}