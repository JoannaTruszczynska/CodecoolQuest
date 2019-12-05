using System.Collections.Generic;
using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;

namespace Codecool.Quest
{
    public static class Sort
    {
        public static void SearchForThings(Thing matchedItem, GameMap _map)
        {
            var player = _map.Player;
            
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
                            playerKeys.Add((Key) item);
                    }

                    Door door = (Door) matchedItem;
                    door.KeyLock(playerKeys);
                    break;
            }
        }

        public static int SearchForActors(Actor matchedActor, GameMap map)
        {
            switch (matchedActor.Type)
            {
                case "skeleton":
                    map.Player.Fight(matchedActor, map);
                    if (map.Player.Health <= 0)
                    {
                        return 0;
                    }
                    break;

                case "cow":
                    map.Player.Fight(matchedActor, map);
                    break;
                    
            }

            return 1;
        }
    }
}