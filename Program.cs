using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 35;
            const int screenHeight = 55;
            Console.Title = "Running in the Woods";
            Console.SetWindowSize(screenHeight, screenWidth);
            Console.SetBufferSize(screenHeight, screenWidth);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("***Welcome to the Running in the Woods game!***");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(16, 6);
            Console.WriteLine("U want to start the game ? ");
            Console.ForegroundColor= ConsoleColor.DarkBlue;
            Console.SetCursorPosition(24, 7);
            Console.Write("Y/N - ? ");
            string choiceOfGame = Console.ReadLine();

            if (choiceOfGame == "y")
            {
                Console.Clear();
                //making some useful stuff and a map
                bool closedOrNot = true;

                Console.CursorVisible = false;
                //Map based on a big array
                char[,] map =
                {
                { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                { '#','X',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ','X','#',' ',' ',' ',' ',' ',' ',' ','X','#',' ',' ',' ','X','#','X','X','#','X','#','X',' ',' ',' ',' ','X','#'},
                { '#',' ',' ','#',' ',' ','X',' ','#','#','#',' ',' ',' ','#',' ','#','#','#','#','#','#','#',' ',' ','X','#','X',' ',' ',' ','#',' ','#','#',' ','#',' ',' ',' ','#',' ',' ','#'},
                { '#',' ',' ','#',' ','#','#','#','#',' ','#','X',' ',' ','X',' ','#','X','X',' ',' ',' ','#',' ',' ',' ','#','#',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ','#','#',' ',' ','#'},
                { '#',' ',' ','#',' ',' ','#','X','#',' ','#','X','X',' ','#',' ','#','X','X',' ',' ',' ','#',' ',' ',' ','#','X',' ','#',' ','#',' ','#','#',' ','#','#','#',' ','#',' ','#','#'},
                { '#',' ',' ',' ',' ',' ','#',' ','#',' ','#','#','#','#','#',' ','#','X',' ',' ',' ',' ','#',' ','#',' ','#',' ','#','#',' ',' ','X',' ','#',' ','#',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ','#',' ','#',' ','#',' ',' ',' ',' ','#','#',' ','#',' ',' ','#','#',' ',' ','#','#','#','#',' ','#','#','#','#','#','#','#','#'},
                { '#','#','#','#',' ',' ','#',' ',' ','#','#','#','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#','X',' ',' ','#',' ',' ',' ',' ',' ',' ','#',' ',' ','X',' ','#'},
                { '#',' ',' ',' ',' ',' ','#','#',' ','#',' ',' ',' ',' ',' ',' ','#',' ','#','#','#','#',' ',' ','#',' ',' ','#',' ','#',' ','#',' ',' ','X','X','X',' ',' ',' ','X','X','X','#'},
                { '#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','X','#',' ',' ',' ',' ',' ',' ',' ',' ','X','#',' ',' ',' ',' ',' ',' ','#',' ',' ','X',' ','#'},
                { '#',' ',' ',' ','#',' ','#','#',' ',' ','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#','#','#','#','X','#','#','#','#','#','#','#','#',' ','#','#','#','#'},
                { '#',' ',' ',' ','#',' ',' ','#',' ','X','#',' ',' ','#','X',' ',' ',' ',' ',' ',' ','#',' ','#','#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ',' ',' ','#',' ',' ','#','#','#','#',' ',' ','#','#','#','#','#',' ',' ',' ','#',' ','X','#',' ','#',' ','#',' ',' ','#','#','#','#','#','X','X','#','#','#','#','#','#'},
                { '#','X',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#',' ','#',' ','#','#',' ','#','X','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#'},
                { '#','X','X',' ','#',' ',' ',' ',' ',' ','X','X',' ',' ',' ',' ','X','#',' ',' ',' ',' ',' ',' ',' ',' ','#','X','X','#',' ','#','X',' ',' ','#',' ',' ',' ',' ','#','X','X','#'},
                { '#','#','#',' ','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                { '#','X','#',' ','#','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','X','X',' ',' ',' ',' ','X','X','#','X',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#'},
                { '#',' ','#',' ','#','#','#',' ','#',' ',' ','#',' ','#',' ',' ',' ','#','X',' ',' ',' ',' ',' ',' ','X','#','X','#','#','#',' ',' ','#',' ',' ','#',' ',' ',' ','#','X','X','#'},
                { '#',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#',' ',' ',' ',' ','#','#','#',' ','#','#','#','#','#','#',' ',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#','#','#','#'},
                { '#',' ','#','#','#','#',' ',' ','#',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ','#',' ','#','X','X','#'},
                { '#','X','#','X','X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#'},
                { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},

            };

                //making characters coordinates 
                int userX = 6, userY = 6;
                //making backpacks array
                char[] backpak = new char[1];

                //game cycle, which works on "closedOrNot" bool stuff(Which is crap, do not use this sytem ever)
                while (closedOrNot == true)
                {

                    Console.CursorVisible = false;
                    //Making treasures in this if-stuff
                    if (map[userX, userY] == 'X')
                    {
                        map[userX, userY] = 'o';
                        char[] tempBag = new char[backpak.Length + 1];
                        for (int temp = 0; temp < backpak.Length; temp++)
                        {
                            tempBag[temp] = backpak[temp];
                        }
                        tempBag[tempBag.Length - 1] = 'X';
                        backpak = tempBag;
                    }
                    //making sort-of UI
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(0, 24);
                    Console.WriteLine("U got to collect all 71 treasures. Go ahead, and get them");
                    Console.WriteLine("@ - You");
                    Console.WriteLine("X - Treasure");
                    Console.WriteLine("# - Wall");
                    //Console.WriteLine("You have only: " + TreasureCount + " treasures ");
                    Console.Write("BackPack:");
                    for (int b = 0; b < backpak.Length; b++)
                    {
                        Console.Write(backpak[b] + " ");
                    }
                    //Map drawing

                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(map[i, j]);
                        }
                        Console.WriteLine();

                    }

                    //something like game ending
                    if (backpak.Length == 71)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Congratilation! U've found all 71 treasures!");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("U wanna continue? y/n -- ");
                        Console.CursorVisible = true;
                        string chooseOfContinueOrNot = Console.ReadLine();
                        if (chooseOfContinueOrNot == "y")
                        {
                            break;
                        }
                        else if (chooseOfContinueOrNot == "n")
                        {
                            break;
                        }
                    }
                    //making character and his movement
                    Console.SetCursorPosition(userY, userX);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('@');
                    ConsoleKeyInfo charKey = Console.ReadKey();
                    switch (charKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (map[userX - 1, userY] != '#')
                            {
                                userX--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (map[userX + 1, userY] != '#')
                            {
                                userX++;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (map[userX, userY - 1] != '#')
                            {
                                userY--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (map[userX, userY + 1] != '#')
                            {
                                userY++;
                            }
                            break;


                    }
                }

            }
            else if(choiceOfGame != "y")
            {

            }


        }
    }
}
