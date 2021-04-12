using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherExam;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WeatherService();

            // Unit Test - Get Single Weather for Tel Aviv
            Console.WriteLine("Unit Test - Get Single Weather for Tel Aviv");
            try
            {
                var test1 = service.GetWeather("Tel Aviv").Result;
                Console.WriteLine(test1.ToString());
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=============================================================");

            // Unit Test 2 - Get Multiple weather forecast for "Tel Aviv", "New York", "London", "Tokyo"
            Console.WriteLine("Unit Test 2 - Get Multiple weather forecast for Tel Aviv, New York, London, Tokyo");
            try
            {
                var test2 = service.GetWeathers(new string[] { "Tel Aviv", "New York", "London", "Tokyo" }).Result;
                test2.ToList().ForEach(c => Console.WriteLine(c.ToString()));
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=============================================================");

            // Unit Test 3 - Try get single weather for empty string
            Console.WriteLine("Unit Test 3 - Try get single weather for empty string");
            try
            {
                var test3 = service.GetWeather("").Result;
                Console.WriteLine(test3.ToString());
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=============================================================");

            // Unit Test 4 - Try get single weather for city that didn't exists
            Console.WriteLine("Unit Test 4 - Try get single weather for city that didn't exists");
            try
            {
                var test4 = service.GetWeather("qrehgefgvadv").Result;
                Console.WriteLine(test4.ToString());
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=============================================================");

            // Unit Test 5 - Get Multiple weather forecast for empty array
            Console.WriteLine("Unit Test 5 - Get Multiple weather forecast for empty array");
            try
            {
                var test5 = service.GetWeathers(new string[0]).Result;
                test5.ToList().ForEach(c => Console.WriteLine(c.ToString()));
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
                else
                    Console.WriteLine(ex.Message);
            }
            Console.WriteLine("=============================================================");

            Console.ReadLine();
        }
    }
}
