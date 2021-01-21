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


            
            //VerticalLine vertLinePart = new VerticalLine(axisY+1, axisY+5, axisX, '.');
            //VerticalLine vertLinePartt = new VerticalLine(axisY+1, axisY+5, axisX + 4, '.');
            //DiagonalLine diagonalPart = new DiagonalLine(axisX, axisY+5, 5, Direction.UP, '.');

            //sympolList.Add(vertLinePart);
            //sympolList.Add(vertLinePartt);
            //sympolList.Add(diagonalPart);


            
            //HorizontalLine horLinePartD = new HorizontalLine(axisX + 7, axisX + 14, axisY+3, '.');
            //DiagonalLine diagonalPartD = new DiagonalLine(axisX + 9, axisY + 2, 2, Direction.UP, '.');
            //DiagonalLine diagonalPartDD = new DiagonalLine(axisX+11, axisY + 1, 2, Direction.DOWN, '.');
            //DiagonalLine diagonalPartDDD = new DiagonalLine(axisX + 8, axisY + 4, 2, Direction.DOWN, '.');
            //DiagonalLine diagonalPartDDDD = new DiagonalLine(axisX + 12, axisY + 5, 2, Direction.UP, '.');

            //sympolList.Add(horLinePartD);
            //sympolList.Add(diagonalPartD);
            //sympolList.Add(diagonalPartDD);
            //sympolList.Add(diagonalPartDDD);
            //sympolList.Add(diagonalPartDDDD);

            
            //VerticalLine vertLinePartI = new VerticalLine(axisY+1, axisY + 5, axisX+17, '.');
            //VerticalLine vertLineParttI = new VerticalLine(axisY+1, axisY + 5, axisX + 21, '.');
            //DiagonalLine diagonalPartI = new DiagonalLine(axisX+17, axisY + 5, 5, Direction.UP, '.');

            //sympolList.Add(vertLinePartI);
            //sympolList.Add(vertLineParttI);
            //sympolList.Add(diagonalPartI);

            
            //HorizontalLine horLinePartT = new HorizontalLine(axisX + 24, axisX + 28, axisY+1, '.');
            //VerticalLine vertLineParttT = new VerticalLine(axisY+1, axisY + 5, axisX + 26, '.');

            //sympolList.Add(horLinePartT);
            //sympolList.Add(vertLineParttT);

            
            //VerticalLine vertLineParttE = new VerticalLine(axisY + 1, axisY + 5, axisX + 31, '.');
            //HorizontalLine horLinePartE = new HorizontalLine(axisX + 32, axisX + 34, axisY + 1, '.');
            //HorizontalLine horLinePartEE = new HorizontalLine(axisX + 32, axisX + 34, axisY + 3, '.');
            //HorizontalLine horLinePartEEE = new HorizontalLine(axisX + 32, axisX + 34, axisY + 5, '.');

            //sympolList.Add(vertLineParttE);
            //sympolList.Add(horLinePartE);
            //sympolList.Add(horLinePartEE);
            //sympolList.Add(horLinePartEEE);

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
