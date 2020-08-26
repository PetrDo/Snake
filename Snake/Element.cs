using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Element
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; private set; }

        public bool IsOffside
        {
            get
            {
                return (
                    (X < 0) || (X >= Console.WindowWidth / 2) ||
                    (Y < 0) || (Y >= Console.WindowHeight)
                    );
            }
        }

        public Element(int x, int y, ConsoleColor c)
        {
            X = x;
            Y = y;
            Color = c;
        }

        public void Print()
        {
            Console.CursorLeft = X * 2;
            Console.CursorTop = Y;
            Console.ForegroundColor = Color;
            // ALT + 219
            Console.Write("██");
        }

        public bool CollidesWith (Element e)
        {
            return ((X == e.X) && (Y == e.Y));
        }
    }
}
