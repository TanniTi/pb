using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snakeee
{
    class Figure
    {
      protected List<Point> pList;

        public virtual void DrawLine()
        {
            foreach (Point p in pList)
            {
                p.Draw();
                //Thread.Sleep(30);
            }
        }

        //проверка для ФИГУР - пересечение одной точки фигуры с другой
        internal bool isHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.isHit(p))
                    return true;  
            }
            return false;
        }

        //проверка для ТОЧЕК - пересечение одной точки с другой
        internal bool isHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.isHit(point))
                    return true;
            }
            return false;
        }
    }
}
