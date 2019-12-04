using System;

namespace Codecool.Quest.Models.Actors
{
    public class Skeleton : Actor
     {
         public override string TileName { get; set; } = "skeleton";

         public override string Type { get; } = "skeleton";
         public override int AttackStrength { get; set; } = 6;

         public override void Move(int dx, int dy)
        {
          

            int EnemyYMoveOffset = 0;
            int EnemyXMoveOffset = dx;
            switch (EnemyXMoveOffset)
            {
                case -1:
                    EnemyYMoveOffset = 0;
                    break;
                case 1:
                    EnemyYMoveOffset = 0;
                    break;
                case 0:
                    EnemyYMoveOffset = dy;
                    break;

            }

            var neighbourCell = Cell.GetNeighbor(EnemyXMoveOffset, EnemyYMoveOffset);
            if (neighbourCell.CanIMoveHere)
            {
                base.Move(EnemyXMoveOffset, EnemyYMoveOffset);
            }
           

         }


         public Skeleton(Cell cell) : base(cell)
         {
         }
     }
 }