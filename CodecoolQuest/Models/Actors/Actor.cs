using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Codecool.Quest.Models.Actors
{
    public abstract class Actor : IDrawable
    {
        public Cell Cell { get; private set; }
        public int Health { get; set; } = 10;

        public abstract string Type { get; }
        public abstract int AttackStrength { get; set; }

        public bool InFightCantMove { get; set; } = false;
        public int X => Cell.X;

        public int Y => Cell.Y;

        public abstract string TileName { get; set; }

        protected Actor(Cell cell)
        {
            Cell = cell;
            Cell.Actor = this;
        }

        public virtual void Move(int dx, int dy)
        {
            var nextCell = Cell.GetNeighbor(dx, dy);
            Cell.Actor = null;
            nextCell.Actor = this;

            nextCell.CanIMoveHere = false;
            Cell.CanIMoveHere = true;
            nextCell.CanIFight = true;
            Cell.CanIFight = false;
            Cell = nextCell;
        }

        public void Disable()
        {
            Cell.Actor = null;
        }

        public void TakeDamage(int damageValue)
        {
            Health -= damageValue;
            InFightCantMove = true;
        }

        public void Fight(Actor enemy, GameMap map)

        {
            enemy.TakeDamage(this.AttackStrength);
            
            if (enemy.Health > 0)
            {
                
                TakeDamage(enemy.AttackStrength);
                if(Health < 0) {
                    Disable();
                }
            }

            else
            {
                enemy.Cell.CanIMoveHere = true;
                enemy.Disable();
                map.GetActors().Remove(enemy);
              
            }
        }
    }
}