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
           Write("Введите количество комнат: ");
            int countRooms;
            while (!int.TryParse(ReadLine(), out countRooms) || countRooms <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите количество комнат: ");
            }

            Write("Введите площадь в кв.м: ");
            double area;
            while (!double.TryParse(ReadLine(), out area) || area <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                Write("Введите площадь в кв.м: ");
            }

            Write("Введите этаж: ");
            int floor;
            while (!int.TryParse(ReadLine(), out floor) || floor <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите этаж: ");
            }

            Write("Введите район: ");
            string region;
            while (string.IsNullOrEmpty(region = ReadLine().Trim()))
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите непустое значение.");
                Write("Введите район: ");
            }

            HavingFlat havingFlat = new HavingFlat(countRooms,area, floor,region);

            flats.Add(havingFlat);
        }
        public void WriteFlat()
        {
            Write("Введите количество комнат: ");
            int countRooms;
            while (!int.TryParse(ReadLine(), out countRooms) || countRooms <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите количество комнат: ");
            }

            Write("Введите площадь в кв.м: ");
            double area;
            while (!double.TryParse(ReadLine(), out area) || area <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                Write("Введите площадь в кв.м: ");
            }

            Write("Введите этаж: ");
            int floor;
            while (!int.TryParse(ReadLine(), out floor) || floor <= 0)
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите целое положительное число.");
                Write("Введите этаж: ");
            }

            Write("Введите район: ");
            string region;
            while (string.IsNullOrEmpty(region = ReadLine().Trim()))
            {
                WriteLine("Некорректный ввод. Пожалуйста, введите непустое значение.");
                Write("Введите район: ");
            }
            SearchAndManageApartments(floor, countRooms, area,region);
        }
        public void SearchAndManageApartments(int floor, int roomCount, double area,string region)
        {
            Flat foundFlat = null;
            foreach (var flat in flats)
            {
                if (flat.Floor == floor &&
                    flat.CountRooms == roomCount &&
                    flat.Region == region &&
                    Math.Abs(flat.Area - area) <= area * 0.1)
                {
                    foundFlat = flat;
                    break;
                }
            }

            if (foundFlat != null)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nНайдена подходящая квартира:");
                ResetColor();
                foundFlat.Info();
                flats.Remove(foundFlat);
            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nПодходящая квартира не найдена. Добавляем новую квартиру в картотеку.");
                ResetColor();
                WriteLine();
                RequiredFlat requiredFlat = new RequiredFlat(roomCount, area, floor, region);
                flats.Add(requiredFlat);
            }
        }
        public void Info()
        {
            //Проверка есть ли вообще квартиры 
            bool requiredFlatsExist = false;
            bool havingFlatsExist = false;

            foreach (var apartment in flats)
            {
                if (apartment is RequiredFlat)
                {
                    requiredFlatsExist = true;
                    break;
                }
            }

            foreach (var apartment in flats)
            {
                if (apartment is HavingFlat)
                {
                    havingFlatsExist = true;
                    break;
                }
            }
            //Если нет, то выводит сообщение 
            if (!requiredFlatsExist && !havingFlatsExist)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Квартиры отсутствуют в картотеке.");
                ResetColor();
                WriteLine();
                return;
            }
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Требуемые: ");
            ResetColor();
            
            foreach (var apartment in flats)
            {
                if(apartment is RequiredFlat)
                {
                    apartment.Info();
                }
            }
            WriteLine();
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("Имеющиеся: ");
           
            WriteLine();
            foreach (var apartamet in flats)
            {
                if(apartamet is HavingFlat)
                {
                    apartamet.Info();
                }
            }

        }
    }
}
