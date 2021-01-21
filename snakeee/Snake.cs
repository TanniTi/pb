using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snakeee
{
    class Snake : Figure
    {

        public Direction direction; 

        //создание змейки (длина, точка начала, направление)
        public Snake(Point tail, int lenght, Direction direction)
        {
            this.direction = direction;//присваеваем текущему экземпляру класса направление (для того, чтобы знать, куда двигаться)

        //    bool f = false;
            pList = new List<Point>();
          
            for (int i = 0; i<lenght; i++)
            {
     
                    Point p = new Point(tail);
                    p.Move(i, direction);//тут: this.direction
                  // Thread.Sleep(20);
                    pList.Add(p);
                    p.Draw();
                    
                    Thread.Sleep(10);
                //}
            }
        }


        
        public Snake(Point head, int lenght)
        {
            this.direction = Direction.RIGHT;

            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {

                Point p = new Point(head);
                p.Move(i, direction);
                pList.Add(p);
                p.Draw();
                Thread.Sleep(60);
            }
        }

        //функция движение (рисуем точку в начале и удаляем в конце)
        internal void Move()
        {
            Point tail = pList.First();//хвосту присваеваем первый элемент списка точек
            pList.Remove( tail );//удаляем хвост из списка
            Point head = GetNextPoint();//получаем следующий элемент после хвоста
            pList.Add(head);//добавляем его в список

            tail.Clear();//стираем хвост из консолт
            head.Draw();//рисуем точку с другой стороны
        }

        //метод для "исчезновения" поточечно змейки в портале
        internal void DeleteSnake()
        {
            do
            {
                

                //сюда вставит тред (в метод занести параметры для треда) и запускаем его из змейки
                //Thread myThread = new Thread(MoveFromPortal(Point tail, int lenght, Direction direction));
                Point tail = pList.First();//хвосту присваеваем первый элемент списка точек
                pList.Remove(tail);//удаляем хвост из списка
                Point head = GetNextPoint();//получаем следующий элемент после хвоста
                tail.Clear();//стираем хвост из консолт
                if (pList.Count == 1)
                {
                    tail = pList.First();
                    pList.Remove(tail);
                    tail.Clear();
                }
              Thread.Sleep(60);
            } while (pList.Count != 0);
           
        }

        //метод шага (змейка сдвигается на 1 вперед)
        private Point GetNextPoint()
        {
            Point head = pList.Last();//Last - последний элемент
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

    

        //метод выбора направления в зависимости от нажатой клавиши
        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.RIGHT)
                        direction = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.LEFT)
                        direction = Direction.RIGHT;
                    break;
                case ConsoleKey.UpArrow:
                    if (direction != Direction.DOWN)
                        direction = Direction.UP;
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.UP)
                        direction = Direction.DOWN;
                    break;
                default: break;
            }
        }

        //метод, когда змейка хавает
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();//присваиваем голове актуальную "голову"
            if (head.isHit(food))
            {
                food.ch = head.ch;//меняем символ еды на на символ змейки
                //food.Draw();
                pList.Add(food);
                return true;
            }
            else
                return false;
        }

        public override void DrawLine()
        { 
            base.DrawLine();
        }

        //метод проверки - не врезалась ли змейка сама в себя
        internal bool isHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i<pList.Count-2; i++)//-2 потому что нельзя врезаться в голову и в предпоследний 
            {
                if (head.isHit(pList[i]))
                    return true;
            }
            return false;
        }
    }
}
