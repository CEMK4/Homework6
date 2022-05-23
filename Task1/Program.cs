using System;
using System.IO;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int choise;
            Console.WriteLine("Введите 1, чтобы вывести данные на экран;\n" +
                "Введите 2, чтобы заполнить данные и добавить новую запись в конец файла.");
            int.TryParse(Console.ReadLine(), out choise);

            if (choise == 1)
                PrintStaff();
            else
                AddStaff();
        }

        ///<summary>
        /// Создаёт или открывает файл с информацией о сотрудниках и записывает новую в конец файла.
        ///</summary>          
        static void AddStaff()
        {
            int ID = File.Exists("staff.txt") ? File.ReadAllLines("staff.txt").Length + 1 : 1;
            using (StreamWriter sw = new StreamWriter("staff.txt", true, Encoding.Unicode))
            {
                int age;
                double heigh;
                DateTime dateOfBirth;
                char key;
                string delim = "#";
                do
                {
                    string note = string.Empty;

                    Console.WriteLine("Введите информацию о сотруднике.");

                    note += ID + delim;
                    note += DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + delim;

                    Console.Write("Ф.И.О: ");
                    note += $"{Console.ReadLine()}{delim}";

                    Console.Write("Возраст: ");
                    while (!int.TryParse(Console.ReadLine(), out age))
                        Console.WriteLine("Ошибка: Введите реальный возраст.");
                    note += age + delim;

                    Console.Write("Рост: ");
                    double.TryParse(Console.ReadLine(), out heigh);
                    note += heigh + delim;

                    Console.Write("Дата рождения: ");
                    while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                        Console.WriteLine("\nОшибка: Введите существующую дату.");
                    note += dateOfBirth.ToShortDateString() + delim;

                    Console.Write("Место рождения: ");
                    note += $"{Console.ReadLine()}";

                    sw.WriteLine(note);

                    Console.Write("Хотите добавить ещё одного сотрудника? (д/н)\t");
                    key = (char)Console.Read();
                    ++ID;

                } while (key == 'д');
            }
        }

        /// <summary>
        /// Выводит информацию о сотрудниках.
        /// </summary>        
        static void PrintStaff()
        {
            if (File.Exists("staff.txt"))
                using (StreamReader sr = new StreamReader("staff.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd().Replace('#', ' '));
                }
            else
                Console.WriteLine("Файла с информацией о сотрудниках не существует.");
        }
    }
}
