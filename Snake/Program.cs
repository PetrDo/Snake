using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake(ConsoleColor.Yellow, ConsoleColor.Green);

            Console.CursorVisible = false;

            while (snake.IsAlive)
            {
                snake.Print();
                snake.Move();
                Thread.Sleep(snake.Delay);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.RightArrow)
                        snake.Direction = Direction.Right;
                    if (key.Key == ConsoleKey.LeftArrow)
                        snake.Direction = Direction.Left;
                    if (key.Key == ConsoleKey.UpArrow)
                        snake.Direction = Direction.Up;
                    if (key.Key == ConsoleKey.DownArrow)
                        snake.Direction = Direction.Down;
                    if (key.Key == ConsoleKey.Q)
                        break;
                }
            }

            Console.Beep(150, 300);
            Console.Beep(800, 200);
            Console.Beep(150, 300);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.WriteLine("End of Game");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
