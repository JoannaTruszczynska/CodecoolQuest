using System.Security.Claims;
using Codecool.Quest.Models.Actors;

namespace Codecool.Quest.Models.Things
{
    /// <summary>
    /// Torch - increase the player's view range
    /// </summary>
    public class Torch : Thing
    {
        public Torch(Cell cell) : base(cell: cell)
        {
            
        }

        public override string TileName { get; } = "torch";
        public override string Type { get; } = "item";
        public override string Subtype { get; } = "accessories";
        private int ExtraSightRange { get; } = 4;
        
        /// <summary>
        /// This method increases the player's view range
        /// </summary>
        /// <param name="actor">player</param>
        public override void UpdateOwnerProperties(Actor actor)
        {
            var player = (Player) actor;
            player.SightRange += ExtraSightRange;
        }
    }
}