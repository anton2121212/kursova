using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Makler
{
    class HavingFlat : Flat
    {
        public HavingFlat() { }
        public HavingFlat(int countRooms, double area, int floor, string region):base(countRooms, area, floor, region) { }
        public override void Info()
        {
            WriteLine($"Количество комнат: {CountRooms}; Площадь: {Area} кв.м; Этаж: {Floor}; Район: {Region}");
        }
    }

}
