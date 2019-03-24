using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //Отображение статистики
    class StatisticsDisplay : IObsorver<WeatherCity>, IDisplayElement
    {
        private WeatherCity weather;
        private IObserverable weatherData;

        public StatisticsDisplay(IObserverable weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Register(this);
        }

        public void Update(WeatherCity weather)
        {
            this.weather = weather;
            Display();
        }

        public override string ToString()
        {
            return $"Статистична температура в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }

        public void Display()
        {
            Console.WriteLine(this);
        }
    }
}
