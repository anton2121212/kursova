using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makler
{
    /// <summary>
    /// Класс описывающий квартиру
    /// </summary>
    public abstract class Flat
    {
        public int CountRooms { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public string Region { get; set; }
        public Flat() { }
        public Flat(int countRooms, double area, int floor, string region)
        {
            CountRooms = countRooms;
            Area = area;
            Floor = floor;
            Region = region;
        }
        public abstract void Info();
        
    }
}
