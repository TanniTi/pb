using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakeee
{

    class Walls 
    {
        private List<Figure> wallList;

        public Walls(int axisX, int axisY)
        {
            wallList = new List<Figure>();

            HorizontalLine horLineTop = new HorizontalLine(1, axisX, 1, '.');
            HorizontalLine horLineBottom = new HorizontalLine(1, axisX, axisY, '.');
            VerticalLine vertLineTop = new VerticalLine(1, axisY, 1, '.');
            VerticalLine vertLineBottom = new VerticalLine(1, 14, axisX, '.');
            VerticalLine vertLineBottom_ = new VerticalLine(21, axisY, axisX, '.');

            wallList.Add(horLineTop);
            wallList.Add(horLineBottom);
            wallList.Add(vertLineTop);
           // wallList.Add(vertLineTop_);
            wallList.Add(vertLineBottom);
            wallList.Add(vertLineBottom_);
           // wallList.Add(vertLinePortalLeft);
        }

        public Walls(int axisX_1, int axisX_2, int axisY_1, int axisY_2,  char c)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            HorizontalLine menu_upLine = new HorizontalLine(axisX_1, axisX_2, axisY_1, c);
            HorizontalLine menu_downLine = new HorizontalLine(axisX_1, axisX_2, axisY_2, c);
            VerticalLine menu_leftLine = new VerticalLine(axisY_1, axisY_2, axisX_1, c);
            VerticalLine menu_rightLine = new VerticalLine(axisY_1, axisY_2, axisX_2, c);

            menu_downLine.DrawLine();
            menu_upLine.DrawLine();
            menu_leftLine.DrawLine();
            menu_rightLine.DrawLine();
        }

        public void Draw()
        {
            foreach (Figure f in wallList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                f.DrawLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        internal bool isHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.isHit(figure))
                    return true;
            }
            return false;
        }




    }
}
