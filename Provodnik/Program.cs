using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7practic
{
    internal class Options
    {
        ConsoleKey Key_Pressed;
        public string path;
        public string path1;
        public string File_Name;
        public string Directory_Name;
        public void Coise()
        {

            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Выход из меню вариаций - Esc\n ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  Новый файл - F2");
            Console.WriteLine("  Удаление файла - F3");
            Console.WriteLine("  Новая директория - F4");
            Console.WriteLine("  Удаление директории - F5");
            Console.ResetColor();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.WriteLine("Путь создания файла: ");
                    path = Console.ReadLine();
                    Console.WriteLine("Наименование файл ");
                    File_Name = Console.ReadLine();

                    File.Create(path + @"\" + File_Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Отлично! Файл создан");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                else if (key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine("Пусть для удаления");
                    path = Console.ReadLine();

                    File.Delete(path);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Удаление файла успешно");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                else if (key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    Console.WriteLine("Укажите путь для создания папки: ");
                    path = Console.ReadLine();
                    Console.WriteLine("Укажите имя: ");
                    Directory_Name = Console.ReadLine();

                    Directory.CreateDirectory(path + @"\" + Directory_Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Папка создана");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;
                }

                else if (key.Key == ConsoleKey.F5)
                {
                    Console.Clear();
                    Console.WriteLine("Укажите путь для удаления папки: ");
                    path = Console.ReadLine();

                    Directory.Delete(path, true);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Папка удалена");
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    break;

                }

                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
