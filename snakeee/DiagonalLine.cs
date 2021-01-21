using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snakeee
{
    class DiagonalLine : Figure
    {
        public DiagonalLine(int axisX, int axisY, int n, Direction direction, char ch)
        {
            pList = new List<Point>();
            if (direction == Direction.UP)
            {
                for (int i = 0; i < n; i++)
                {
                    Point p = new Point(axisX+i, axisY-i, ch);
                    pList.Add(p);
                }

            }

            if (direction == Direction.DOWN)
            {
                for (int i = 0; i < n; i++)
                {
                    Point p = new Point(axisX + i, axisY + i, ch);
                    pList.Add(p);
                }
            }
        }

        //public override void DrawLine()
        //{
        //    base.DrawLine();
        //}

    }
}
