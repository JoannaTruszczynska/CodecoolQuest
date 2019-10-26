using Codecool.Quest.Models.Actors;
using System.IO;

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
                                break;
                            }
                            case '#':
                            {
                                cell.CellType = CellType.Wall;
                                break;
                            }
                            case '.':
                            {
                                cell.CellType = CellType.Floor;
                                break;
                            }
                            case 's':
                            {
                                cell.CellType = CellType.Floor;
                                new Skeleton(cell);
                                break;
                            }
                            case '@':
                            {
                                cell.CellType = CellType.Floor;
                                map.Player = new Player(cell);
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