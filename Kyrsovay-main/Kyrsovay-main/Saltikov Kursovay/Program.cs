using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltikov_Kursovay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Kirill\Downloads\Kyrsovay-main\Kyrsovay-main\Saltikov Kursovay\File.txt";
            DoublyLinkedList library = new DoublyLinkedList();
            library.LoadFromFile(filePath);
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\tМеню:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Найти книгу по автору");
                Console.WriteLine("4. Найти книгу по названию");
                Console.WriteLine("5. Найти книгу по году выпуска");
                Console.WriteLine("6. Вывести все книги");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("7. Выход");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Выберите действие: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректные данные!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите название книги: ");
                        string title = Console.ReadLine();
                        Console.Write("Введите автора книги: ");
                        string author = Console.ReadLine();
                        Console.Write("Введите год выпуска книги: ");
                        int year;
                        if (!int.TryParse(Console.ReadLine(), out year) || year < DateTime.Now.Year - 1000 || year > DateTime.Now.Year)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректная дата");
                            continue;
                        }
                        library.AddBook(new Book { Title = title, Author = author, Year = year });
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Книга добавлена в библиотеку.");
                        break;

                    case 2:
                        Console.Write("Введите название книги для удаления: ");
                        string titleToRemove = Console.ReadLine();
                        library.RemoveBook(titleToRemove);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Книга удалена из библиотеки.");
                        break;

                    case 3:
                        Console.Write("Введите имя автора для поиска книг: ");
                        string authorToFind = Console.ReadLine();
                        library.FindByAuthor(authorToFind);
                        break;

                    case 4:
                        Console.Write("Введите название книги для поиска: ");
                        string titleToFind = Console.ReadLine();
                        library.FindByTitle(titleToFind);
                        break;

                    case 5:
                        Console.Write("Введите год выпуска книги для поиска: ");
                        if (!int.TryParse(Console.ReadLine(), out year))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректные данные!");
                            continue;
                        }
                        library.FindByYear(year);
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Список книг в библиотеке:");
                        library.DisplayAllBooks();
                        break;

                    case 7:
                        library.SaveToFile(filePath);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Выберите действие из списка.");
                        break;
                }
            }
        }
    }
}
