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
            CurrentConditionDisplay display1 = new CurrentConditionDisplay();
            StatisticsDisplay display2 = new StatisticsDisplay();
            ForecastDisplay display3 = new ForecastDisplay();

            //підписуємо підписників на sinopticUa
            sinopticUa.EventWeather += display1.OnNext;
            sinopticUa.EventWeather += display2.OnNext;
            sinopticUa.EventWeather += display3.OnNext;
            sinopticUa.EventWeather += new Action<WeatherCity>((new  ForecastDisplay()).OnNext);
            //sinopticUa.EventWeather += x=> {   new WeatherCity("Lviv"); };

            //Змінюємо показники погоди
            sinopticUa.SetMeasuremants(weather1);
            //Розсилаємо погоду
            sinopticUa.Notify();

            sinopticUa.SetMeasuremants(weather2);
            sinopticUa.Notify();
            sinopticUa.SetMeasuremants(weather3);
            sinopticUa.Notify();

            Console.WriteLine();

            display2.canUse = false; // display2 відписується від sinopticUa 
            sinopticUa.EventWeather -= display1.OnNext; // sinopticUa відписує display1

            sinopticUa.Notify();

            Console.ReadLine();
        }
    }
}
