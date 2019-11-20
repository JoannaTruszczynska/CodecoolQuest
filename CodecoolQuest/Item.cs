using Codecool.Quest.Models;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest
{
    public abstract class Item : Thing
    {
        protected Item(Cell cell) : base(cell)
        {
        }

    }
}