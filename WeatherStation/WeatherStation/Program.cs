﻿using System;
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

            //підписуємо підписників на sinopticUa
            //sinopticUa.Subscribe(display1);
            //sinopticUa.Subscribe(display2);
            //sinopticUa.Subscribe(display3);
            //IDisposable unsubscriber1 = sinopticUa.Subscribe(display1);
            //IDisposable unsubscriber2 = sinopticUa.Subscribe(display2);
            //IDisposable unsubscriber3 = sinopticUa.Subscribe(display3);
            sinopticUa.EventWeather += display1.OnNext;
            sinopticUa.EventWeather += display2.OnNext;
            sinopticUa.EventWeather += display3.OnNext;
            //sinopticUa.EventWeather += (new  ForecastDisplay(sinopticUa)).OnNext;
            //sinopticUa.EventWeather += x=> {   new WeatherCity(""); };
            //sinopticUa(weather1);

            //Змінюємо показники погоди
            //sinopticUa.SetMeasurement(weather1);
            //////sinopticUa.SetMeasurement(weather1);
            //sinopticUa.SetMeasurement(weather2);
            //sinopticUa.SetMeasurement(weather3);

            //Console.WriteLine();
            //unsubscriber2.Dispose(); //Відписка другого підписника через ConcreteSubject.Unsubscriber.Dispose()
            //sinopticUa.Notify();
   
            sinopticUa.NotifyNew(weather1);
            sinopticUa.NotifyNew(weather2);
            sinopticUa.NotifyNew(weather3);

            Console.WriteLine();
            sinopticUa.EventWeather -= display2.OnNext;  // display2 відписується від sinopticUa 
            //sinopticUa.Notify();
            sinopticUa.NotifyNew(weather1);

            Console.WriteLine();
            sinopticUa.Dispose(); //відписуємо всіх
            sinopticUa.Notify();

            Console.ReadLine();
        }
    }
}
