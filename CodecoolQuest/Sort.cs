using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;
using System.Collections.Generic;

namespace Codecool.Quest
{
    public static class Sort
    {
        public static void SortForThings(Thing matchedItem, GameMap _map)
        {
            var player = _map.Player;

            foreach (var VARIABLE in player.GetItems())
            {
            }

            switch (matchedItem.Type)
            {
                case "item":
                    matchedItem.UpdateOwnerProperties(player);
                    matchedItem.Disable();
                    _map.GetThings().Remove(matchedItem);
                    break;

                case "weapon":
                    matchedItem.UpdateOwnerProperties(player);
                    player.TileName = "armedplayer";
                    player.Weapon = matchedItem;
                    matchedItem.Disable();
                    player.GetItems().Remove(matchedItem);
                    break;

                case "door":
                    List<Key> playerKeys = new List<Key>();
                    // keys = _map.Player.GetItems().ForEach(item => item.Subtype == "dupa");
                    foreach (var item in player.GetItems())
                    {
                        if (item.Subtype == "key")
                            playerKeys.Add((Key)item);
                    }

                    Door door = (Door)matchedItem;
                    door.KeyLock(playerKeys);
                    break;

                case "meat":
                    matchedItem.UpdateOwnerProperties(player);
                    matchedItem.Disable();
                    _map.GetThings().Remove(matchedItem);
                    break;
            }
        }

        public static void SortForActors(Actor matchedActor, GameMap map)
        {
            switch (matchedActor.Type)
            {
                case "skeleton":
                    map.Player.Fight(matchedActor, map);
                    if (matchedActor.Health <= 5)
                    {
                        matchedActor.TileName = "ghost";
                    }
                    break;

                case "cow":
                    map.Player.Fight(matchedActor, map);
                    Meat meat = new Meat(map.GetCell(matchedActor.X, matchedActor.Y));
                    map.SetThing(meat);
                break;

                case "ghost":
                    map.Player.Fight(matchedActor, map); 
                break;


            }
        }
    }
}