using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Saltikov_Kursovay
{
    /// <summary>
    ///  Класс, представляющий сам двусвязный список
    /// </summary>
    class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        // Метод для добавления книги в конец списка
        public void AddBook(Book book)
        {
            Node newNode = new Node { Data = book };

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        // Метод для удаления книги из списка
        public void RemoveBook(string title)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Title == title)
                {
                    if (current == head)
                    {
                        head = head.Next;
                        if (head != null)
                            head.Previous = null;
                    }
                    else if (current == tail)
                    {
                        tail = tail.Previous;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        // Метод для поиска книги по автору
        public void FindByAuthor(string author)
        {
            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Author == author)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Книги данного автора не найдены.");
        }

        // Метод для поиска книги по названию
        public void FindByTitle(string title)
        {
            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Title == title)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Книга с данным названием не найдена.");
        }

        // Метод для поиска книги по году выпуска
        public void FindByYear(int year)
        {
            if (year < DateTime.Now.Year - 1000 || year > DateTime.Now.Year)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный год выпуска.");
                return;
            }

            Node current = head;
            bool found = false;

            while (current != null)
            {
                if (current.Data.Year == year)
                {
                    Console.WriteLine(current.Data);
                    found = true;
                }
                current = current.Next;
            }

            if (!found)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Книги с данным годом выпуска не найдены.");
        }

        // Метод для вывода всех книг в списке
        public void DisplayAllBooks()
        {
            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        string title = parts[0];
                        string author = parts[1];
                        if (int.TryParse(parts[2], out int year))
                        {
                            AddBook(new Book { Title = title, Author = author, Year = year });
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден. Будет создан новый файл при сохранении.");
            }
        }
        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Node current = head;
                while (current != null)
                {
                    writer.WriteLine($"{current.Data.Title};{current.Data.Author};{current.Data.Year}");
                    current = current.Next;
                }
            }
        }
    }
}
