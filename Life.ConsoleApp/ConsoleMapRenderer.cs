using System;
using System.Collections.Generic;
using System.Linq;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;

namespace Life.ConsoleApp
{
    public class ConsoleMapRenderer : IRenderer
    {
        //public IMap Map { get; set; }
        public Dictionary<string, char> GameObjectSymbols => new Dictionary<string, char>()
        {
            {"Duck", 'D'},
            {"Fish", 'F'},
            {"Rabbit", 'R'},
            {"Sparrow", 'S'},
            {"Turtle", 'T'},
            {"Algae", 'A'},
            {"Cabbage", 'C'},
            {"Tree", '?'},
            {"Rock", '@'}
        };
        public Dictionary<AreaType, char> AreaTypeSymbols => new Dictionary<AreaType, char>()
        {
            {AreaType.Land,'.'},
            {AreaType.Water,'~'}
        };
        public Dictionary<AreaType, ConsoleColor> AreaTypeColors => new Dictionary<AreaType, ConsoleColor>()
        {
            {AreaType.Land, ConsoleColor.DarkYellow},
            {AreaType.Water, ConsoleColor.Blue}
        };

        public void DrawMap(IGameSessionState gameSessionState, int stepNumber)
        {
            var map = gameSessionState.Map;
            int n = 1;
            string border = "";
            border = border.PadLeft(map.WorldDimensions.X * 5, '-');

            Console.Write($"\nMap at the start of step: {stepNumber}");
            Console.Write("\n" + border + "\n");

            for (int y = map.WorldDimensions.Y; y > 0; y--)
            {
                for (int x = 1; x < map.WorldDimensions.X + 1; x++)
                {
                    var selectedTile = map.Tiles.First(tile =>
                        tile.Coordinates.Equals(new Coordinates(x, y)));
                    string objectsOnTile = $"{selectedTile.GameObjectsOnTile.Count}";
                    if (selectedTile.GameObjectsOnTile.Count == 1)
                    {
                        var selected = selectedTile.GameObjectsOnTile.First();
                        //Защита на случай, если добавили новое существо, но не добавили для него символ
                        if (GameObjectSymbols.ContainsKey(selected.GetType().Name))
                        {
                            objectsOnTile = GameObjectSymbols[selected.GetType().Name].ToString();
                        }
                    }
                    DrawTile(objectsOnTile, new Coordinates(x, y),map);
                    if (n < map.WorldDimensions.X)
                    {
                        n++;
                    }
                    else
                    {
                        n = 1;
                        Console.Write("\n" + border + "\n");
                    }
                }
            }
        }
        private void DrawTile(string objectsCount, Coordinates coordinates, IMap map)
        {
            var landSymbol = '=';
            var backgroundColor = ConsoleColor.Black;
            var foregroundColor = ConsoleColor.White;
            var gameTile = map.Tiles.First(tile => tile.Coordinates.Equals(coordinates));
            if (AreaTypeSymbols.ContainsKey(gameTile.AreaType))
            {
                landSymbol = AreaTypeSymbols[gameTile.AreaType];
            }

            if (AreaTypeColors.ContainsKey(gameTile.AreaType))
            {
                backgroundColor = AreaTypeColors[gameTile.AreaType];
            }

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write($"|{landSymbol}  {objectsCount}");
            Console.ResetColor();
        }
    }
}
