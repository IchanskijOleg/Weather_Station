using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //Отображение прогноза
    class ForecastDisplay : IObsorver<WeatherCity>, IDisplayElement
    {
        private WeatherCity weather;
        private IObserverable weatherData;

        public ForecastDisplay(IObserverable weatherData)
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
            return $"Прогноз температури в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }

        public void Display()
        {
            Console.WriteLine(this);
        }
    }
}
