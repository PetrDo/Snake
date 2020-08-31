using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

using Snake.Levels;

namespace Snake
{
    enum Direction { Right, Left, Up, Down};

    class Snake
    {
        public bool IsAlive { get; private set; }
        public Direction Direction { get; set; }

        private List<Element> snake;
        private Element food;
        private Random random;

        private ConsoleColor snakeColor;
        private ConsoleColor foodColor;

        private Level level;
        public Snake(ConsoleColor snakeColor, ConsoleColor foodColor)
        {
            snake = new List<Element>(); 
            snake.Add(new Element(29, 12, snakeColor));
            snake.Add(new Element(30, 12, snakeColor));

            this.snakeColor = snakeColor;
            this.foodColor = foodColor;
            IsAlive = true;
            Direction = Direction.Right;

            random = new Random();
            food = new Element(0, 0, foodColor);
            GenerateFood();

            level = new LevelA(snake.Count, this);

        }

        public Level Level
        {
            get { return level; }
            set { level = value; }
        }

        public int Delay
        {
            get { return level.Delay; }
        }

        public void Print()
        {
            foreach (Element e in snake) e.Print();
            food.Print();
        }

        public void Move()
        {
            if (IsAlive)
            {
                Element newHead = new Element(snake[snake.Count - 1].X, snake[snake.Count - 1].Y, snakeColor);
            
                // coordinates of the newHead depend on the direction of travel
                switch (Direction)
                {
                    case Direction.Right:
                        newHead.X++;
                        break;
                    case Direction.Left:
                        newHead.X--;
                        break;
                    case Direction.Up:
                        newHead.Y--;
                        break;
                    case Direction.Down:
                        newHead.Y++;
                        break;
                    // Default Right
                    default:
                        newHead.X++;
                        break;
                }

                // Food is eaten if its coordinates equal to the coordinates of the newHead
                // and new food is generated at random coordinates
                if (newHead.CollidesWith(food))
                {
                    GenerateFood();
                }
                // tail removal in case of no food is eaten
                else
                {
                    Console.CursorLeft = snake[0].X * 2;
                    Console.CursorTop = snake[0].Y;
                    Console.Write("  ");
                    snake.RemoveAt(0);
                }

                // newHead outside of the Console
                if (newHead.IsOffside) IsAlive = false;

                // newHead collides with other element of the snake
                foreach(Element e in snake)
                {
                    if (newHead.CollidesWith(e)) IsAlive = false;
                }

                // finally newHead becomes part of the snake
                snake.Add(newHead);
                // level up based on length of the sanke body
                level.UpdateLength(snake.Count);
            } 
        }

        private void GenerateFood()
        {
            bool invalidCoordinates = true;

            // repeat until new food does not overlap with snake body
            while (invalidCoordinates)
            {
                food.X = random.Next(Console.WindowWidth / 2);
                food.Y = random.Next(Console.WindowHeight);

                invalidCoordinates = false;

                foreach(Element e in snake)
                {
                    if (food.CollidesWith(e))
                        invalidCoordinates = true;
                }
            }
            Console.Beep(900, 50);
        }
    }
}
