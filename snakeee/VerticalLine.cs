using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snakeee
{
    class VerticalLine : Figure
    {

        public VerticalLine(int yUp, int yDown, int x, char ch)
        {
            pList = new List<Point>();

            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, ch);
                pList.Add(p);
            }
        }

    }
}
