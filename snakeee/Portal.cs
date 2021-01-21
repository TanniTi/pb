using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakeee
{
    class Portal : Figure
    {
        private List<Figure> portalList;
        //конструктор
        public Portal(int start, int end, int level, bool itX)
        {
            portalList = new List<Figure>();
            if (itX)
            {
                VerticalLine verticalPortal = new VerticalLine(start, end, level, '>');
                portalList.Add(verticalPortal);

            }
            else
            {
                VerticalLine verticalPortal = new VerticalLine(start, end, level, ' ');
                portalList.Add(verticalPortal);
            }
        }


        internal void Draw()
        {

           foreach (var f in portalList)
           {
               Console.ForegroundColor = ConsoleColor.Magenta;
               f.DrawLine();
           }
        }

        internal bool isHit(Figure snake)
        {
            foreach (var v in portalList)
            {
                if (v.isHit(snake))
                    return true;
            }
            return false;
        }
    }
}
