using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EF.Lib;
using EF.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Utils
{
    public class Task3
    {
        // Реализуйте следующие LINQ запросы для базы дан­
        //     ных «Страны»:
        // ■ Отобразить все столицы, у которых в названии есть
        //     буквы a, p;
        // ■ Отобразить все столицы, у которых название начи­
        // нается с буквы k;
        /// ///////////////////////////////////////////
        //     ■ Отобразить название стран, у которых площадь на­
        //     ходится в указанном диапазоне;

        //     ■ Отобразить название стран, у которых количество
        //     жителей больше указанного числа.
        public static void PrintCountryContaining(char symbol)
        {
            using (DataBase db = DataBase.Init())
            {
                var countries = from tab in db.TabCountry
                    where tab.Name.Contains(symbol.ToString())
                    select tab;
                foreach (var country in countries)
                {
                    Console.WriteLine($"Name country - {country.Name}");
                }
            }
        }

        public static void PrintCountryStartsWith(string symbol) // Не может сформировать запрос для метода StartsWith()
        {
            using (DataBase db = DataBase.Init())
            {
                var countries = db.TabCountry
                    .FromSqlRaw("select * from TabCountry where TabCountry.Name LIKE {0}", $"{symbol}%").ToList();
                foreach (var country in countries)
                {
                    Console.WriteLine($"Name {country.Name}");
                }
            }
        }

        public static void PrintCountryArea(int min, int max)
        {
            using (DataBase db = DataBase.Init())
            {
                // var countries = db.TabCountry
                //     .FromSqlRaw(
                //         "select * from TabCountry where TabCountry.Area >= {0} AND TabCountry.Area <= {1}", min, max)
                //     .ToList();

                var countries = from tab in db.TabCountry
                    where tab.Area >= min
                    where tab.Area <= max
                    select tab;

                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        public static void PrintCountryResidents(int number)
        {
            using (DataBase db = DataBase.Init())
            {
                var countries = from tab in db.TabCountry
                    where tab.Residents >= number
                    select tab;
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }
    }
}