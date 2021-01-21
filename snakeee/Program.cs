using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snakeee
{
    class Program
    {
        static int speed;
        static int score;
        static ConsoleKeyInfo key_enter;
        static int currentRecord;
        static string path = @"record.dat";

        static void Main(string[] args)
        {
            Console.Title = "My little snake";
            Console.CursorVisible = false;
           for (; ; )
           {
            Console.Clear();
            Console.SetBufferSize(80, 25);//устанавнивание размеры консоли
         
            mainMenu();

            do
            {
                Console.Clear();
                score = 0;
               

                //отрисовка рамочки
                Walls walls = new Walls(78, 23);
                walls.Draw();

                //отрисовка портала (0-y,1-x)
                Portal portalRight = new Portal(15, 20, 78, false);
                portalRight.Draw();
                Portal portalLeft = new Portal(3, 5, 1, true);
                portalLeft.Draw();


                //отрисовка строки с рекордом
                Console.SetCursorPosition(50, 0);
                Console.Write("BEST RESULT: ");

                //считывание из файла "рекорда"
                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                    {
                        while (reader.PeekChar() > -1) //-1 - это если символ отсутствует
                        {
                            currentRecord = reader.ReadInt32();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.SetCursorPosition(63, 0);
                Console.Write(currentRecord);


                //создание змейки
                Point p = new Point(4, 4, '*');//начальная точка змейки
                p.Draw();
                Snake snake = new Snake(p, 6, Direction.RIGHT);
                //snake.DrawLine();

                //класс для создания и обработки точки-еды
                FoodCreator foodCreator = new FoodCreator(80, 25, '+');//координаты - границы консоли
                Point food;
                do
                {
                    food = foodCreator.CreateFood();//создаем еду
                    food.Draw();
                } while (snake.isHit(food));

                //бесконечный цикл
                while (true)
                {
                    //строка с текущим результатом
                    Console.SetCursorPosition(77, 0);
                    Console.Write(score);


                    if (walls.isHit(snake) || snake.isHitTail())
                    {
                        //если текущий рекорд меньше текущего значения, то переписываем файл с рекордом
                        if (currentRecord<score)
                        {
                            currentRecord = score;
                            try
                            {
                                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                                {
                                    writer.Write(currentRecord);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        Console.SetCursorPosition(32, 10);
                        Console.Write("Game over!");
                        Console.SetCursorPosition(32, 11);
                        Console.Write("Continue? (Enter)");
                        key_enter = Console.ReadKey();
                        Console.WriteLine();
                        break;
                    }

                    //если змейка врезалась в правый портал
                    if (portalRight.isHit(snake))
                    {
                        Thread myThread = new Thread(new ThreadStart(Count));
                        myThread.Start(); // запускаем поток

                        //поточечно стираем змейку и удаляем ее из списка
                        snake.DeleteSnake();

                        snake = new Snake(p, 6 + score, Direction.RIGHT);

                     

                    }

                    if (snake.Eat(food))
                    {
                        score++;

                        do
                        {
                            food = foodCreator.CreateFood();
                            food.Draw();
                        } while (snake.isHit(food));
                    }
                    else
                        snake.Move();
                    Thread.Sleep(speed);//скорость

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);//тут баг (был)
                        snake.HandleKey(key.Key);
                    }
                    //Thread.Sleep(60);
                    //snake.Move();
                }


                //Console.ReadLine();//ожидание нажатия
            } while (key_enter.Key == ConsoleKey.Enter);
          }

        }

        //основное меню приложения
        public static void mainMenu()
        {

            Walls menuWalls = new Walls(25,55,3,20,'.');

            string[] arr = new string[] { "PLAY", "SETTINGS", "EXIT", "INFO"};
            Menu menu = new Menu(7,arr);

            ////создаем указатель с конструктором без параметров - параметры задаются на первый элемент, т.е. слово "play"
            ////класс хранит:
            ////координаты указателя, 
            //// методы: перемещение, .....
            //Pointer menuPointer = new Pointer();
            ConsoleKeyInfo menuKey;
            int code = 0;
            while (code == 0)
                {
                    menuKey = Console.ReadKey();
                    code = menu.MenuPointer(menuKey);
                }


            if (code == 1)
                speed = 60;
            if (code == 2)
                mainMenu();
            if (code == 3)
                speed = 30;
                 
        }

         
        public static void Count()
        {
            Thread.Sleep(20);
            Point p = new Point(4,4,'*');//начальная точка змейки
            
            Snake snake = new Snake(p, 6+score);
        }

        
    }

}
