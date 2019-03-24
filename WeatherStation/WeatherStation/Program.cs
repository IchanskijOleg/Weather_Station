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
            //WeatherCity weather2 = new WeatherCity(city2);
            //WeatherCity weather3 = new WeatherCity(city3);

            WeatherData wData = new WeatherData();
            //wData.Register(display1);
            //wData.Register(display2);
            //wData.Register(display3);

            CurrentConditionDisplay display1 = new CurrentConditionDisplay(wData);
            StatisticsDisplay display2 = new StatisticsDisplay(wData);
            ForecastDisplay display3 = new ForecastDisplay(wData);

            wData.SetMeasurement(weather1);

            //Console.WriteLine(weather1);
            //Console.WriteLine(weather2);
            //Console.WriteLine(weather3);

            //Action<WeatherCity> sinopticUa = wData.MeasurementChanged;
            //sinopticUa(weather1);
            //Action<WeatherCity> sinopticUa = display1.Update;

            //for (int i = 0; i < 4; i++)
            //{
            //    sinopticUa(weather1);
            //    Console.WriteLine(sinopticUa.ToString()); 
            //}
            Console.ReadLine();
        }
    }
}
