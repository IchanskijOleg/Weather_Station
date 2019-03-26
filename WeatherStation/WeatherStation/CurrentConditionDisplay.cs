using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //отображение текущего состояния
    class CurrentConditionDisplay : IObsorver<WeatherCity>, IDisplayElement
    {
        private WeatherCity weather;
        private IObserverable weatherData;

        public CurrentConditionDisplay(IObserverable weatherData)
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
            return $"Поточна температура в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }

        public void UnSubscribe()
        {
            weatherData.Delete(this);
        }

        public void Display()
        {
            Console.WriteLine(this);
        }
    }
}
