using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakeee
{
    class Point
    {
        protected int x;
        protected int y;
        public char ch;

        public Point(int x, int y, char ch)
        {
            this.x = x;
            this.y = y;
            this.ch = ch;
        }

        //конструктор создания точки с помощью другой точки
        public Point (Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.ch = p.ch;
        }

        //перемещение точки на offset шагов в определенную сторону 
        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    x = x + offset;
                    break;
                case Direction.LEFT:
                    x = x - offset;
                    break;
                case Direction.UP:
                    y = y - offset;
                    break;
                case Direction.DOWN:
                    y = y + offset;
                    break;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        //сишарп магия (переопределение toString)
        public override string ToString()
        {
            return x + ", " + y + ", " + ch;
        }

        //затираем точку
        public void Clear()
        {
            ch = ' ';
            Draw();
        }


        internal bool isHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
