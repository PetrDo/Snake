using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Levels
{
    class LevelA : Level
    {
        //public LevelA(Level level) : this(level.Length, level.Snake) { }
        public LevelA(int length, Snake snake)
        {
            this.length = length;
            this.snake = snake;
            this.delay = 150;
            limit = 5;
        }
        
        public override void UpdateLength(int length)
        {
            this.length = length;
            if (length > limit)
            {
                snake.Level = new LevelB(this);
            }
        }
    }
}