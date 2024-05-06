using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saltikov_Kursovay
{
    /// <summary>
    /// Класс, представляющий узел двусвязного списка
    /// </summary>
    class Node
    {
        public Book Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
