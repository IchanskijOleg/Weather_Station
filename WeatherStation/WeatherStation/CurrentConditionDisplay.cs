using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //отображение текущего состояния
    class CurrentConditionDisplay : IObserver<WeatherCity>, IDisplayElement
    {
        private WeatherCity weather;
        IDisposable unsubscriber;
        private IObservable<WeatherCity> weatherData;

        public CurrentConditionDisplay(IObservable<WeatherCity> weatherData)
        {
            this.weatherData = weatherData;
            unsubscriber = weatherData.Subscribe(this);
        }

        public override string ToString()
        {
            return $"Поточна температура в {weather.City} = {weather.CelsiusCurrent}C, вітер {weather.SpeedMetersPerSecond} м/с, хмарність {weather.Clouds}%.";
        }

        public void Display()
        {
            Console.WriteLine(this);
        }

        //реалізація стандартного інтерфейсу IObserver<T>

        public void OnCompleted()
        {
            unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Observer {0}, Error: {1}", weather.ToString(), error.Message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        // Аналог Update(argument) - модель проталкивания.
        public void OnNext(WeatherCity weather)
        {
            this.weather = weather;
            Display();
        }
    }
}
