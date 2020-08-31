using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Levels
{
    class LevelC : Level
    {
        public LevelC(Level level) : this(level.Length, level.Snake) { }
        public LevelC(int length, Snake snake)
        {
            this.length = length;
            this.snake = snake;
            this.delay = 60;
            limit = 10;
        }

        public override void UpdateLength(int length)
        {
            this.length = length;
            if (length > limit)
            {
                //snake.Level = new LevelD(this);
            }
        }
    }
}