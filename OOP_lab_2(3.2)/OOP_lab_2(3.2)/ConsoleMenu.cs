/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_2_3._2_
{
    internal class ConsoleMenu
    {

        int menuResult;
        protected string[] menuItems = new string[] {"Для пересування по меню використовуйте стрiлки \"вгору\" та \"вниз\", щоб обрати натиснiть \"Enter\" \n (Не використовуйте стрiлки для завершення дiй!) ",
                 "1. Додати трапецію.",
                "2. Вивести як дженерік", "3. Вивести як масив(нон-дженерік).",
           "4. Вивести як бінарне дерево", "5. Виконати операцiю зi студентами", "6. Знайти особу за iм'ям та прiзвищем", "7. Видалити файл", "8. Вихiд з програми"};
        protected int counter = 0;

        delegate void method();


        public ConsoleMenu()
        {

        }
        public static void InputError() => Console.WriteLine("Введено некоректнi данi, спробуйте ще раз:");
        public static string ReadItem() => Console.ReadLine();
        public static void WriteItem(string s) => Console.WriteLine(s);
        public int PrintMenu() // функція повторного виведення меню
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        // оформлення зовнішнього вигляду меню
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey(); // оформлення "руху" по меню
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
        public void ShowMenu()
        {
            do
            {
                ConsoleMenu menu = this;
                method[] methods = new method[] { Text, Method1, Method2, Method3, Method5, Method6, Method7, Method8, Exit };
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продовження натиснiть будь-яку клавiшу");
                Console.ReadKey();
            } while (menuResult != menuItems.Length - 1);
        }

        void Text()
        {
            Console.WriteLine("Це просто текст, вiн нi за що не вiдповiдає");
        }
        void Method1()
        {
            string s = MainIO.Reader();
            if (s == null)
            {
                Console.WriteLine("Файл порожнiй або не створений, будь ласка, додайте елемент для початку роботи");
            }
            Console.WriteLine(s);

        }
        void Method2()
        {
            Creation.CreateStudent();

        }
        void Method3()
        {
            Creation.CreateFootballPlayer();

        }

        void Method5()
        {
            Creation.CreateLawyer();
        }
        void Method6()
        {
            Student student = new Student();
            var type = student.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
            string str = MainIO.Search(props.Count);
            Console.WriteLine(str);
        }
        void Method7()
        {
            string Finder = Inputs.InputProf();
            string FName = Inputs.InputFirstName();
            string LName = Inputs.InputLastName();
            int props = Inputs.GetProps(Finder);
            string str = MainIO.SearchFIO(FName, LName, props);
            Console.WriteLine(str);
        }
        void Method8()
        {
            MainIO.Delete();
            Console.WriteLine("Файл успiшно видалено!");
        }

        static void Exit()
        {
            Console.WriteLine("Додаток завершує роботу!");
            Environment.Exit(1);
        }

    }
}
*/