using Codecool.Quest.Models.Actors;
using System.IO;

namespace Codecool.Quest.Models {
    public class MapLoader {
        public static GameMap LoadMap() {
            StreamReader stream = new StreamReader("/map.txt");
            string firstline = stream.ReadLine();
            string[] firstline_split = firstline.Split(' ');

            int width = int.Parse(firstline_split[0]);
            int height = int.Parse(firstline_split[1]);

            GameMap map = new GameMap(width, height, CellType.EMPTY);

            for (int y = 0; y < height; y++) {
                string line = stream.ReadLine();

                for (int x = 0; x < width; x++) {
                    if (x < line.Length) {
                        Cell cell = map.getCell(x, y);

                        switch (line[x]) {
                            case ' ': {
                                    cell.CellType = CellType.EMPTY;
                                    break;
                                }

                            case '#': {
                                    cell.CellType = CellType.WALL;
                                    break;
                                }

                            case '.': {
                                    cell.CellType = CellType.FLOOR;
                                    break;
                                }

                            case 's': {
                                    cell.CellType = CellType.FLOOR;
                                    new Skeleton(cell);
                                    break;
                                }

                            case '@': {
                                    cell.CellType = CellType.FLOOR;
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