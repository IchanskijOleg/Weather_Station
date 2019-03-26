using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //отображение текущего состояния
    class CurrentConditionDisplay :IObserver<WeatherCity>, IDisplayElement
    {
        private WeatherCity weather;
        private IObservable<WeatherCity> weatherData;

        public CurrentConditionDisplay(IObservable<WeatherCity> weatherData)
        {
            this.weatherData = weatherData;
            weatherData.Subscribe(this);
        }

        public override string ToString()
        {
            return $"Поточна температура в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }

        public void Display()
        {
            Console.WriteLine(this);
        }

        //реалізація стандартного інтерфейсу IObserver
        public void OnNext(WeatherCity weather)
        {
            this.weather = weather;
            Display();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            (weatherData as IDisposable).Dispose();
        }
    }
}
