using System;
using System.Linq;
using EF.Lib;
using EF.Model;
using System.Data.Sql;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Application.Utils
{
    public class Task4
    {
        // Реализуйте следующие LINQ запросы для базы дан­
        //     ных «Страны»:
        // ■ Показать топ­5 стран по площади;
        // ■ Показать топ­5 столиц по количеству жителей;
        //     ■ Показать страну с самой большой площадью;
        //     ■ Показать столицу с самым большим количеством
        // жителей;
        // ■ Показать страну с самой маленькой площадью в Европе
        // ■ Показать среднюю площадь стран в Европе;


        //     ■ Показать топ­3 городов по количеству жителей для
        //     конкретной страны;

        // ■ Показать общее количество стран;

        //     ■ Показать часть света с максимальным количеством
        // стран;
        // ■ Показать количество стран в каждой части света.
        
        public static void PrintCountCountry()
        {
            using (DataBase db = DataBase.Init())
            {
                var countryCount = (from tab in db.TabCountry
                    select tab).Count();
                Console.WriteLine(countryCount);
            }
        }

        public static void PrintTopCityByResidentsByCountry(string countryExpected)
        {
            using (DataBase db = DataBase.Init())
            {
                var country = (from tab in db.TabCountry
                    where tab.Name == countryExpected
                    select tab).FirstOrDefault();

                var bigCity = (from tab in db.TabBigCity
                    where tab.IdCountry == country
                    orderby tab.Residents descending
                    select tab.Name).Take(3);

                foreach (var city in bigCity)
                {
                    Console.WriteLine(city);
                }
            }
        }


        public static void PrintSmallOneCountryByArea()
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<Country> countries = (from tab in db.TabCountry
                    orderby tab.Area ascending
                    select tab).Take(1);
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        public static void PrintAverageOneCountryByArea()
        {
            using (DataBase db = DataBase.Init())
            {
                var countries = from tab in db.TabCountry
                    select tab;

                Console.WriteLine($"Средняя площадь стран - {countries.Average(c => c.Area)}");
            }
        }


        public static void PrintTopOneCountryByResidents()
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<Country> counties = (from tab in db.TabCountry
                    orderby tab.Residents descending
                    select tab).Take(1);
                foreach (var country in counties)
                {
                    Console.WriteLine(country.Id + " " + country.Name);
                }
            }
        }

        public static void PrintTopOneCountryByArea()
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<Country> countries = (from tab in db.TabCountry
                    orderby tab.Area descending
                    select tab).Take(1);
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        public static void PrintTopFiveCountryByArea()
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<Country> countries = (from tab in db.TabCountry
                    orderby tab.Area descending
                    select tab).Take(5);
                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        public static void PrintTopFiveCountryByResidents()
        {
            using (DataBase db = DataBase.Init())
            {
                IQueryable<Country> countries = (from tab in db.TabCountry
                    orderby tab.Residents descending
                    select tab).Take(5);

                foreach (var country in countries)
                {
                    Console.WriteLine(country.Name);
                }
            }
        }
    }
}