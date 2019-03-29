using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //Отображение прогноза
    class ForecastDisplay : IObserver, IDisplayElement
    {
        // Подписчик.
        //delegate void Observer(WeatherCity weather);

        private WeatherCity weather;
        public bool canUse = true;
        public override string ToString()
        {
            return $"Прогноз температури в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }

        public void Display()
        {
            Console.WriteLine(this);
        }

        // Аналог Update(argument) - модель проталкивания.
        public void OnNext(WeatherCity weather)
        {
            if (!canUse)
                return;
            this.weather = weather;
            Display();
        }
    }
}


