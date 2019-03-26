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

            //створюємо Subject
            WeatherData sinopticUa = new WeatherData();

            //створюємо Observers
            CurrentConditionDisplay display1 = new CurrentConditionDisplay(sinopticUa);
            StatisticsDisplay display2 = new StatisticsDisplay(sinopticUa);
            ForecastDisplay display3 = new ForecastDisplay(sinopticUa);
            
            //Змінюємо показники погоди
            sinopticUa.SetMeasurement(weather1);
            //sinopticUa.SetMeasurement(weather1);
            sinopticUa.SetMeasurement(weather2);
            sinopticUa.SetMeasurement(weather3);

            Console.WriteLine();
            sinopticUa.Notify();
            sinopticUa.Delete(display3); //sinopticUa відписує display3
            display1.UnSubscribe(); // display1 відписується від sinopticUa 
            Console.WriteLine();
            sinopticUa.Notify();

            //Action<WeatherCity> sinopticUa = wData.MeasurementChanged;
            //sinopticUa(weather1);
            //Action<WeatherCity> sinopticUa = display1.Update;

            Console.ReadLine();
        }
    }
}
