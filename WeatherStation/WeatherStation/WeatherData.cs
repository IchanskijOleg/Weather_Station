using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherData : IObservable<WeatherCity>, IDisposable
    {
        List<IObserver<WeatherCity>> masWeather;
        private WeatherCity weather;

        public WeatherData()
        {
            masWeather = new List<IObserver<WeatherCity>>();
        }

        public void Notify()
        {
            foreach (IObserver<WeatherCity> observer in masWeather)
            {
                if (this.weather == null)
                    observer.OnError(new NullReferenceException());
                else
                    observer.OnNext(this.weather); // модель проштовхування
            }
        }

        public void MeasurementChanged()
        {
            Notify();
        }

        public void SetMeasurement(WeatherCity weather)
        {
            СWriteLog.WriteFile(weather.ToString()); //пишемо лог
            if (this.weather != weather)
            {
                this.weather = weather;
                MeasurementChanged();
            }
        }

        public IDisposable Subscribe(IObserver<WeatherCity> observer)
        {
            if (!masWeather.Contains(observer))
                masWeather.Add(observer);
            return new Unsubscriber(masWeather, observer);
        }

        /// <summary>
        /// Відписати всіх підписників.
        /// </summary>
        public void Dispose()
        {
            masWeather.Clear();
        }

        // Nested Class
        class Unsubscriber : IDisposable
        {
            List<IObserver<WeatherCity>> observers;
            IObserver<WeatherCity> observer;

            public Unsubscriber(List<IObserver<WeatherCity>> observers, IObserver<WeatherCity> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observers.Contains(observer))
                    observers.Remove(observer);
                else
                    observer.OnError(new Exception("Данный подписчик не подписан на издателя."));
            }
        }

    }
}
