using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakeee
{
    class GraphSymbol : Figure
    {
        private List<Figure> sympolList;

        public GraphSymbol(int axisX, int axisY, int weight)
        {
            sympolList = new List<Figure>();
        }

        public void Draw()
        {
            foreach (Figure f in sympolList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                f.DrawLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        internal bool isHit(Figure figure)
        {
            foreach (var wall in sympolList)
            {
                if (wall.isHit(figure))
                    return true;
            }
            return false;
        }
    }
}
