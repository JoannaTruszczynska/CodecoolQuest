﻿using Codecool.Quest.Models.Actors;
using Codecool.Quest.Models.Things;
using System.Collections.Generic;

namespace Codecool.Quest.Models
{
    public class GameMap
    {
        public int Height { get; }
        public int Width { get; }
        private readonly Cell[,] _cells;
        public Player Player { get; set; }

        private List<Thing> _things = new List<Thing>();

        public List<Thing> GetThings()
                 {
                     return _things;
                 }
        public void SetThing(Thing thing)
        {
            _things.Add(thing);
        }

        private List<Actor> _actors = new List<Actor>();
        public void SetActor(Actor actor)
        {
            _actors.Add(actor);
        }
        
        public List<Actor> GetActors()  // without player
        {
            return _actors;
        }
        
        public Skeleton Skeleton { get; set; }
        

        public GameMap(int width, int height, CellType defaultCellType)
        {
            Width = width;
            Height = height;
            _cells = new Cell[width, height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    _cells[x, y] = new Cell(this, x, y, defaultCellType);
                }
            }
        }
        public Cell GetCell(int x, int y)
        {
            if (x >= _cells.GetLength(0) || y >= _cells.GetLength(1) || x < 0 || y < 0)
            {
                return null;
            }
            return _cells[x, y];
        }
    }
}