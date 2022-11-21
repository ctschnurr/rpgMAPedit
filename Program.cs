using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGmap
{
    internal class Program
    {
        static char[,] map = new char[,] // dimensions defined by following data:
        {
            {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
            {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
            {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
            {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
            {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
            {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        };

        static int mapHeight = map.GetLength(0);
        static int mapWidth = map.GetLength(1);

        static void Main(string[] args)

        {
         //   Console.SetWindowSize((mapWidth * 3) + 2, (mapHeight * 3) + 3);
         //   Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Console.CursorVisible = false;

            DisplayMap();
            Console.ReadKey(true);
            Console.Clear();

            DisplayMap(1);
            Console.ReadKey(true);
            Console.Clear();

            DisplayMap(2);
            Console.ReadKey(true);
            Console.Clear();

            DisplayMap(3);
            Console.ReadKey(true);

            DisplayMap(4);
            Console.ReadKey(true);

            DisplayMap(5);
            Console.ReadKey(true);

            DisplayMap(6);
            Console.ReadKey(true);
        }

        static void DisplayMap()
        {

            for (int mapX = 0; mapX < mapHeight; mapX++)
            {
                Console.SetCursorPosition(0, mapX);
                for (int mapY = 0; mapY < mapWidth; mapY++)
                {
                    Console.Write(map[mapX, mapY]);
                }
                Console.WriteLine();
                Console.WriteLine("Raw Map Data");
            }

        }

        static void DisplayMap(int scale)
        {

            int mapV = 0;
            int drawV;

            int mapH = 0;

            int rowNum = 1;
            int colNum = 1;

            //    switch (scale)
            //    {
            //        case 1:
            //            rowNum = mapHeight;
            //            colNum = mapWidth;
            //            break;
            //
            //        case 2:
            //            rowNum = mapHeight / 2;
            //            colNum = mapWidth / 2;
            //            break;
            //
            //        case 3:
            //            rowNum = 0;
            //            colNum = 0;
            //            break;
            //    }

            int mapRow = rowNum + 1;
            int mapCol = colNum + 1;

            int drawH = mapCol;

            for (int column = 0; column < mapHeight; column++)
            {
                for (int row = 0; row < mapWidth; row++)
                {
                    drawV = mapRow;
                    for (int v = 0; v < scale; v++)
                    {
                        char tile = (map[mapV, mapH]);

                        Console.SetCursorPosition(drawH, drawV);
                        for (int h = 0; h < scale; h++)
                        {

                            switch (tile)
                            {
                                case '^':

                                    Random rand = new Random();
                                    int diceRoll = rand.Next(3);

                                    if (diceRoll == 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                    }

                                    else if (diceRoll != 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }

                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    Console.Write(tile);
                                    break;

                                case '`':
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(tile);
                                    break;

                                case '~':
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write(tile);
                                    break;

                                case '*':
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(tile);
                                    break;

                                default:
                                    Console.Write(tile);
                                    break;

                            }

                            Console.ResetColor();
                        }
                        drawV = drawV + 1;
                    }
                    mapH = mapH + 1;
                    drawH = drawH + scale;


                }
                mapRow = mapRow + scale;
                drawH = mapCol;

                mapV = mapV + 1;
                mapH = 0;
            }

            Console.SetCursorPosition(colNum, rowNum);

            Console.Write("╔");

            for (int x = 0; x < (mapWidth * scale); x++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╗");

            for (int y = 1; y <= (mapHeight * scale); y++)
            {
                Console.SetCursorPosition(colNum, rowNum + y);
                Console.Write("║");
                Console.SetCursorPosition(colNum + ((mapWidth * scale) + 1), rowNum + y);
                Console.Write("║");
            }

            Console.SetCursorPosition(colNum, mapRow);

            Console.Write("╚");

            for (int x = 0; x < (mapWidth * scale); x++)
            {
                Console.Write("═");
            }

            Console.Write("╝");

            Console.SetCursorPosition(colNum, mapRow + 1);

            Console.Write(" Scale: " + scale);

        }
    }
}
