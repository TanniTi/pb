using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snakeee
{
    class Menu
    {
        string[] arr;
        int here_axisY;



        public Menu(int axisY, string[] arr)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            this.arr = arr;
            here_axisY = axisY;

            //рисуем менюшку в столбик с учетом кол-ва эл-ов
            for (int i = 0; i < arr.Length; i++)
            {
                Console.SetCursorPosition(40 - (arr[i].Length / 2), axisY);
                Console.Write(arr[i]);
                axisY = axisY + 3;//надо бы оптимизирвать

            }
            //ставим указатель на первый эл-т
            Pointer(here_axisY, '*');

        }
        
        //функция перехода между пунктами меню
        //function: transition beetween menu`s elements
        public int MenuPointer(ConsoleKeyInfo key)
        {
            if (this.arr.Length== 1)
                return 0;
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    if (here_axisY == 16)
                        break;
                    else
                    {
                        Pointer(here_axisY, ' ');
                        Pointer(here_axisY+3, '*');

                        here_axisY = here_axisY + 3;


                        Console.Beep(2000, 105);//signal
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (here_axisY == 7)
                        break;
                    else
                    {
                        Pointer(here_axisY, ' ');
                        Pointer(here_axisY- 3, '*');
                        Console.SetCursorPosition(45, here_axisY);

                        here_axisY = here_axisY - 3;

                        Console.Beep(2000,105);
                    }
                    break;
                    //if press Enter
                case ConsoleKey.Enter:
                    if (here_axisY == 7)
                    {
                        Console.Clear();
                        return 1; 
                    }

                        if (here_axisY == 10)
                        {
                            ConsoleKeyInfo menuKey;
                            int speed_level;
                            string str1 = "MODE: EASY";
                            string str2 = "MODE: DIFFICULT";
                            string screen_str = str1;
                            speed_level = 1;
                            for (; ; )
                            {
                                Console.Clear();
                                Console.SetCursorPosition(53, 21);
                                Console.Write("Press '->' to select speed");
                                Console.SetCursorPosition(53, 23);
                                Console.Write("Press 'Enter' to play!");
                                Console.SetCursorPosition(38, 7);
                                Console.Write(screen_str);

                                menuKey = Console.ReadKey();
                                switch (menuKey.Key)
                                {
                                    case ConsoleKey.Enter:
                                        Console.Clear();
                                        return speed_level;

                                    case ConsoleKey.RightArrow:
                                        if (screen_str == str1)
                                        {
                                            screen_str = str2;
                                            speed_level = 3;
                                        }
                                            
                                        else
                                        {
                                            screen_str = str1;
                                            speed_level = 1;
                                        }
                                        break;
                                }
                            }
                            
                            
                        }
                    else if (here_axisY == 16)
                    {
                        ConsoleKeyInfo myKey;
                        do
                        {

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.SetCursorPosition(30, 8);
                            Console.Write("2019 - Сreator: Tanni");
                            Console.SetCursorPosition(30, 9);
                            Console.Write("All rights are patented :Р");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            Console.SetCursorPosition(57, 23);
                            Console.Write("Press 'Esc' for return");
                          
                            myKey = Console.ReadKey();

                        } while (myKey.Key != ConsoleKey.Escape);
                       
                            Console.Clear();
                            return 2;
                            
                        
                    }
                    else if (here_axisY == 13)
                    {
                        Environment.Exit(0);
                    }

                    break;

            }
            return 0;
    }
        //function: Pointer drawing
        private void Pointer(int here_axisY, char p)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(35, here_axisY);
            Console.Write(p);
            Console.SetCursorPosition(44, here_axisY);
            Console.Write(p);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
