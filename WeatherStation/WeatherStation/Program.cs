using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new OpenWeatherAPI("eb873a38c50a5a2519861054b5cbaae1");

            Console.WriteLine("OpenWeatherAPI Example Application");
            Console.WriteLine();

            Console.WriteLine("Enter city to get weather data for:");
            var city = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Fetching weather data for '{city}'");
            var results = client.Query(city);

            Console.WriteLine($"The temperature in {city} is {results.Main.Temperature.CelsiusCurrent}C. There is {results.Wind.SpeedFeetPerSecond} f/s wind in the {results.Wind.Direction} direction.");

            Console.ReadLine();
        }
    }
}
