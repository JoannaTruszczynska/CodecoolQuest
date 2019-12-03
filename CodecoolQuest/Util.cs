using Codecool.Quest.Models;
using Codecool.Quest.Models.Actors;
using System;

namespace Codecool.Quest
{
    public static class Util

    {
        public static void SkeletonMove(GameMap _map, Cell neighbourCell, Skeleton skeleton)
        {
            Random rand = new Random();
            
                int EnemyYMoveOffset = 0;
                int EnemyXMoveOffset = rand.Next(-1, 2);
                switch (EnemyXMoveOffset)
                {
                    case -1:
                        EnemyYMoveOffset = 0;
                        break;
                    case 1:
                        EnemyYMoveOffset = 0;
                        break;
                    case 0:
                        EnemyYMoveOffset = rand.Next(-1,2);
                        break;

                }
                

                neighbourCell = skeleton.Cell.GetNeighbor(EnemyXMoveOffset, EnemyYMoveOffset);
                if (neighbourCell.CanIMoveHere)
                {
                    skeleton.Move(EnemyXMoveOffset, EnemyYMoveOffset);
                }

                //Console.WriteLine("Skeleton X " + skeleton.X + "Skeleton Y " + skeleton.Y);
            
        }
    }
}