using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Makler
{
    class ActionsFlats
    {
        private List<Flat> flats = new List<Flat>();
        public void AddFlat()
        {
           WriteLine("Введите количество комнат:");
            int countRooms;
            while (!int.TryParse(ReadLine(), out countRooms) || countRooms <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                WriteLine("Введите количество комнат:");
            }

            WriteLine("Введите площадь:");
            double area;
            while (!double.TryParse(ReadLine(), out area) || area <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                WriteLine("Введите площадь:");
            }

            WriteLine("Введите этаж:");
            int floor;
            while (!int.TryParse(ReadLine(), out floor) || floor <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                WriteLine("Введите этаж:");
            }

            WriteLine("Введите район:");
            string region;
            while (string.IsNullOrEmpty(region = ReadLine().Trim()))
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите непустое значение.");
                WriteLine("Введите район:");
            }

            HavingFlat havingFlat = new HavingFlat(countRooms,area, floor,region);

            flats.Add(havingFlat);
        }
        public void WriteFlat()
        {
            WriteLine("Введите количество комнат:");
            int countRooms;
            while (!int.TryParse(ReadLine(), out countRooms) || countRooms <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                WriteLine("Введите количество комнат:");
            }

            WriteLine("Введите площадь:");
            double area;
            while (!double.TryParse(ReadLine(), out area) || area <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                WriteLine("Введите площадь:");
            }

            WriteLine("Введите этаж:");
            int floor;
            while (!int.TryParse(ReadLine(), out floor) || floor <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                WriteLine("Введите этаж:");
            }

            string region ="";
            SearchAndManageApartments(floor, countRooms, area,region);
        }
        public void SearchAndManageApartments(int floor, int roomCount, double area,string region)
        {
            Flat foundFlat = null;
            foreach (var flat in flats)
            {
                if (flat.Floor == floor &&
                    flat.CountRooms == roomCount &&
                    Math.Abs(flat.Area - area) <= area * 0.1)
                {
                    foundFlat = flat;
                    break;
                }
            }

            if (foundFlat != null)
            {
                WriteLine("Найдена подходящая квартира:");
                foundFlat.Info();
                flats.Remove(foundFlat);
            }
            else
            {
                WriteLine("Подходящая квартира не найдена. Добавляем новую квартиру в картотеку.");
                RequiredFlat requiredFlat = new RequiredFlat(roomCount, area, floor, region);
                flats.Add(requiredFlat);
            }
        }
        public void Info()
        {
            WriteLine("Требуемые: ");
            foreach(var apartment in flats)
            {
                if(apartment is RequiredFlat)
                {
                    apartment.Info();
                }
            }
            WriteLine("Имеющиеся: ");
            foreach(var apartamet in flats)
            {
                if(apartamet is HavingFlat)
                {
                    apartamet.Info();
                }
            }
        }
    }
}
