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

            Console.WriteLine("Виберіть місто для перегляду погоди:");
            var city = Console.ReadLine();
            Console.WriteLine();
            //Console.WriteLine($"Погода в місті '{city}'");
            var results = client.Query(city);

            Console.WriteLine($"Температура в {city} = {results.Main.Temperature.CelsiusCurrent}C, вітер {results.Wind.SpeedMetersPerSecond} м/с, хмарність {results.Clouds.All}%.");

            Console.ReadLine();
        }
    }
}
