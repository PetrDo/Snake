using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Levels
{
    abstract class Level
    {
        protected Snake snake;
        protected int length;
        protected int limit;
        protected int delay;

        // Properties
        public Snake Snake
        {
            get { return snake; }
            //set { snake = value; }
        }
        public int Length
        {
            get { return length; }
            //set { length = value; }
        }

        public int Delay
        {
            get { return delay; }
        }

        public abstract void UpdateLength(int length);
    }
}
