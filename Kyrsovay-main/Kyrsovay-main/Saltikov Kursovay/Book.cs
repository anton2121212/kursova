using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltikov_Kursovay
{
    /// <summary>
    ///  Класс, представляющий книгу
    /// </summary>
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Название: {Title}, Автор: {Author}, Год выпуска: {Year}";
        }
    }
}
