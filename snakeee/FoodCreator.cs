using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakeee
{
    class FoodCreator : Point
    {
       
        private Random random;

        //overloading
        public FoodCreator(int x, int y, char ch) : base(x, y, ch){}
     
        public Point CreateFood()
        {
            random = new Random();
            int x = random.Next(4, this.x - 3);
            int y = random.Next(2, this.y - 2);
            return new Point(x, y, ch);
        }
        
    }
}
