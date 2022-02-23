using System;
using System.Linq;
using Application.Utils;
using EF.Lib;
using EF.Model;

namespace Application
{
    class Application
    {
        static DataBase db = DataBase.Init();

        public static void Main()
        {
            // Task2.PrintAllTab();
            // Task2.PrintNameCountries();
            // Task2.PrintNameBigCity();
            // Task2.PrintNameBigCityByCountry("russia");
            // Task2.PrintBigCityAndResidents(40);
            // Task2.PrintCountryArea(300);
            // Task3.PrintCountryContaining('a');
            // Task3.PrintCountryContaining('p');
            // Task3.PrintCountryStartsWith("R");
            // Task3.PrintCountryArea(50, 200);
            // Task3.PrintCountryResidents(100);
            // Task4.PrintTopFiveCountryByArea();
            // Task4.PrintTopFiveCountryByResidents();
            // Task4.PrintTopOneCountryByResidents();
            // Task4.PrintTopOneCountryByArea();
            // Task4.PrintSmallOneCountryByArea();
            // Task4.PrintAverageOneCountryByArea();
            // Task4.PrintTopCityByResidentsByCountry("Russia");
            // Task4.PrintCountCountry();
        }

        public static void AddCountry(string countryName)
        {
            Country city = new Country()
            {
                Name = countryName,
                Residents = 50,
                Area = 200
            };
            db.TabCountry.Add(city);
            SaveDb();
        }

        public static void AddCity(string cityName)
        {
            //TODO :: переписать поиск по имени страны
            db.TabBigCity.Add(new BigCity()
            {
                IdCountry = db.TabCountry.Find(1),
                Name = cityName,
                Residents = 10
            });

            // using (DataBase cityContext = DataBase.Init())
            // {
            //     var cityQueryable = from country in cityContext.TabCountry
            //         where country.Name == 
            // }
            SaveDb();
        }

        public static void FindCountryIndex(string countryName)
        {
            using (DataBase countryContext = DataBase.Init())
            {
                var countryQueryable = from country in countryContext.TabCountry
                    where country.Name == countryName
                    select country;
            }
            //TODO :: дописать
            //TODO :: узнать id и добавить этот id в TabBigCity , возможно содать новый метод для поиска который вернет id
        }

        public static void SaveDb()
        {
            db.SaveChanges();
        }
    }
}