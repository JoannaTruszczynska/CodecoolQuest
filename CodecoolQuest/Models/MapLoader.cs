﻿using System.Collections.Generic;
using Codecool.Quest.Models.Actors;
using System.IO;
using System.Runtime.InteropServices;

namespace Codecool.Quest.Models
{
    public class MapLoader
    {
        public static GameMap LoadMap()
        {
            using var stream = new StreamReader("map.txt");
            var firstLine = stream.ReadLine();
            var firstLineSplit = firstLine.Split(' ');

            var width = int.Parse(firstLineSplit[0]);
            var height = int.Parse(firstLineSplit[1]);

            var map = new GameMap(width, height, CellType.Empty);
           
            

            for (var y = 0; y < height; y++)
            {
                var line = stream.ReadLine();

                for (var x = 0; x < width; x++)
                {
                    if (x < line.Length)
                    {
                        var cell = map.GetCell(x, y);

                        switch (line[x])
                        {
                            case ' ':
                                {
                                    cell.CellType = CellType.Empty;
                                    cell.CanIMoveHere = false;
                                    cell.CanIFight = false;
                                    break;
                                }
                            case '#':
                                {
                                    cell.CellType = CellType.Wall;
                                    cell.CanIMoveHere = false;
                                    cell.CanIFight = false;
                                    break;
                                }
                            case '.':
                                {
                                    cell.CellType = CellType.Floor;
                                    cell.CanIMoveHere = true;
                                    cell.CanIFight = false;
                                    break;
                                }
                            case 's':
                                {
                                    cell.CellType = CellType.Floor;
                                    cell.CanIMoveHere = false;
                                    cell.CanIFight = true;
                                    map.Skeleton = new Skeleton(cell);
                                    map.skeletonList.Add(map.Skeleton);
                                    break;
                                }
                            case '@':
                                {
                                    cell.CellType = CellType.Floor;
                                    cell.CanIMoveHere = true;
                                    cell.CanIFight = false;
                                    map.Player = new Player(cell);
                                    break;
                                }
                            case 'K':
                                {
                                    cell.CellType = CellType.Key;
                                    cell.CanIMoveHere = true;
                                    cell.CanIFight = false;
                                    break;
                                }
                            case 'D':
                                {
                                    cell.CellType = CellType.Door;
                                    cell.CanIMoveHere = true;
                                    cell.CanIFight = false;
                                    break;
                                }

                        }
                    }
                }
            }

            return map;
        }
    }
}