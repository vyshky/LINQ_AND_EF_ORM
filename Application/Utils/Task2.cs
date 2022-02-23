using System;
using System.Collections.Generic;
using System.Linq;
using EF.Lib;
using EF.Model;

namespace Application.Utils
{
    // Реализуйте следующие LINQ запросы для базы дан­
    // ных «Страны»:
    // ■ Отобразить всю информацию о странах;
    // ■ Отобразить название стран;
    // ■ Отобразить название столиц;
    // ■ Отобразить название крупных городов конкретной
    // страны;
    // ■ Отобразить название столиц с количеством жителей
    // больше пяти миллионов;
    // ■ Отобразить название всех европейских стран;
    // ■ Отобразить название стран с площадью большей
    // конкретного числа.
    public class Task2
    {
        public static void PrintAllTab()
        {
            List<Country> country = new List<Country>();
            using (DataBase c = DataBase.Init())
            {
                c.TabBigCity.ToList();
                country = c.TabCountry.ToList();
            }

            for (int i = 0; i < country.Count; ++i)
            {
                Console.WriteLine($"id = {country[i].Id},name = {country[i].Name},residents = {country[i].Residents}");
                Console.Write("bigCity = ");
                foreach (BigCity city in country[i].BigCity)
                {
                    Console.Write($"{city.Name};");
                }

                Console.WriteLine();
            }
        }

        public static void PrintNameCountries()
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<string> countriesName = from c in db.TabCountry
                    select c.Name;
                Console.WriteLine($"{string.Join(",", countriesName)}");
            }
        }

        public static void PrintNameBigCity()
        {
            using (DataBase db = DataBase.Init())
            {
                var countriesName = from c in db.TabBigCity
                    select c.Name;
                Console.WriteLine($"{string.Join(",", countriesName)}");
            }
        }

        public static void PrintNameBigCityByCountry(string country)
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<ICollection<BigCity>> countriesName = from c in db.TabCountry
                    where c.Name == country
                    select c.BigCity;

                foreach (ICollection<BigCity> cityCollection in countriesName)
                {
                    foreach (BigCity cityName in cityCollection)
                    {
                        Console.WriteLine($"{cityName.Name};");
                    }
                }
            }
        }

        public static void PrintBigCityAndResidents(int number)
        {
            using (DataBase db = DataBase.Init())
            {
                var bigCities = from tab in db.TabBigCity
                    where tab.Residents > number
                    select tab;

                foreach (var bigCity in bigCities)
                {
                    Console.WriteLine($"City - {bigCity.Name},Residents {bigCity.Residents}");
                }
            }
        }

        public static void PrintCountryArea(int number)
        {
            using (DataBase db = DataBase.Init())
            {
                var countries = from tab in db.TabCountry
                    where tab.Area > number
                    select tab;

                foreach (var country in countries)
                {
                    Console.WriteLine($"Name country - {country.Name}");
                }
            }
        }
    }
}