using System;
using System.Collections.Generic;
using System.Diagnostics;
using Codecool.Quest.Models.Actors;
using System.IO;
using System.Runtime.InteropServices;
using Codecool.Quest.Models.Things;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
                                    break;
                                }
                            case '#':
                                {
                                    cell.CellType = CellType.Wall;
                                    cell.CanIMoveHere = false;
                                    break;
                                }
                            case '.':
                                {
                                    cell.CellType = CellType.Floor;
                                    cell.CanIMoveHere = true;
                                    break;
                                }
                            case 's':
                                {
                                    cell.CellType = CellType.Floor;
                                    cell.CanIMoveHere = false;
                                    map.SetActor(new Skeleton(cell));
                                    break;
                                }
                            case '@':
                                {
                                    cell.CellType = CellType.Floor;
                                    cell.CanIMoveHere = true;
                                    map.Player = new Player(cell);
                                    break;
                                }
                            case 'k':
                            {
                                cell.CellType = CellType.Floor;
                                cell.CanIMoveHere = true;
                                Thing blueKey = new Key(cell, "blueKey", "blueKey");
                                map.SetThing(blueKey);
                                break;
                            }
                            case 'b':
                            {
                                cell.CellType = CellType.Floor;
                                cell.CanIMoveHere = true;
                                Thing redKey = new Key(cell, "redKey", "redKey");
                                map.SetThing(redKey);
                                break;
                            }
                            case 'd':
                            {
                                cell.CellType = CellType.Floor;
                                Thing door = new Door(cell, new List<string>(){"blueKey"});
                                map.SetThing(door);
                                break;
                            }
                            case 't':
                            {
                                cell.CellType = CellType.Floor;
                                cell.CanIMoveHere = true;
                                Thing sword = new Sword(cell);
                                map.SetThing(sword);
                                break;
                            }
                            case 'h':
                            {
                                cell.CellType = CellType.Floor;
                                cell.CanIMoveHere = true;
                                Thing heart = new Heart(cell);
                                map.SetThing(heart);
                                break;
                            }
                            case 'l':
                            {
                                cell.CellType = CellType.Hp;
                                cell.CanIMoveHere = false;
                                break;
                            }
                            case 'x':
                            {
                                cell.CellType = CellType.Floor;
                                cell.CanIMoveHere = true;
                                Torch torch = new Torch(cell);
                                map.SetThing(torch);
                                break;
                            }
                            case 'c':
                            {
                                cell.CellType = CellType.Floor;
                                cell.CanIMoveHere = false;
                                Cow cow= new Cow(cell);
                                map.SetActor(cow);
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