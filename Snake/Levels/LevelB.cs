using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Levels
{
    class LevelB : Level
    {
        public LevelB(Level level) : this(level.Length, level.Snake){}
        public LevelB(int length, Snake snake)
        {
            this.length = length;
            this.snake = snake;
            this.delay = 90;
            limit = 8;
        }
        
        public override void UpdateLength(int length)
        {
            this.length = length;
            if (length > limit)
            {
                snake.Level = new LevelC(this);
            }
        }
    }
}