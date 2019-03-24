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
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("OpenWeatherAPI Example Application");
            Console.WriteLine();

            Console.WriteLine("Виберіть місто для перегляду погоди:");
            //var city = Console.ReadLine();
            string city1 = "Hrebinka";
            string city2 = "Kiev";
            string city3 = "London";
            Console.WriteLine();

            WeatherCity weather1 = new WeatherCity(city1);
            WeatherCity weather2 = new WeatherCity(city2);
            WeatherCity weather3 = new WeatherCity(city3);

            Console.WriteLine(weather1);
            Console.WriteLine(weather2);
            Console.WriteLine(weather3);

            Console.ReadLine();
        }
    }
}
