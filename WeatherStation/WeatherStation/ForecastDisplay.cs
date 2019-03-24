using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //Отображение прогноза
    class ForecastDisplay : IObsorver<WeatherCity>
    {
        private WeatherCity weather;

        public void Update(WeatherCity weather)
        {
            this.weather = weather;
        }

        public override string ToString()
        {
            return $"Прогноз температури в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }
    }
}
