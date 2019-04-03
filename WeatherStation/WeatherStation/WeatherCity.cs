﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherCity : IWeatherCity
    {
        //public readonly string City;
        //public readonly double CelsiusCurrent;
        //public readonly double SpeedMetersPerSecond;
        //public readonly double Clouds;
        public string City { get; set; }
        public double CelsiusCurrent { get; set; }
        public double SpeedMetersPerSecond { get; set; }
        public double Clouds { get; set; }
        public WeatherCity()
        {
        }
        public WeatherCity(string city)
        {
            OpenWeatherAPI client = new OpenWeatherAPI("eb873a38c50a5a2519861054b5cbaae1");
            Query results = client.Query(city);
            City = city;
            CelsiusCurrent = results.Main.Temperature.CelsiusCurrent;
            SpeedMetersPerSecond = results.Wind.SpeedMetersPerSecond;
            Clouds = results.Clouds.All;
        }

        public override string ToString()
        {
            return $"Температура в {City} = {CelsiusCurrent}C, вітер {SpeedMetersPerSecond} м/с, хмарність {Clouds}%.";
        }

        public string ToFile()
        {
            return $"City={City}\r\nCelsiusCurrent={CelsiusCurrent}\r\nSpeedMetersPerSecond={SpeedMetersPerSecond}\r\nClouds={Clouds}";
        }
    }
}
