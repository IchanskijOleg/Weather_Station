using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherData: IObservable<WeatherCity>, IDisposable
    {
        List<IObserver<WeatherCity>> masWeather;
        private WeatherCity weather;
        IObserver<WeatherCity> observer;

        public WeatherData()
        {
            masWeather = new List<IObserver<WeatherCity>>();
        }

        public void Notify()
        {
            foreach (var item in masWeather)
            {
                item.OnNext(weather);
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
            this.observer = observer;
            masWeather.Add(observer);
            return (observer as IDisposable);
        }

        public void Dispose()
        {
            masWeather.Remove(this.observer); 
        }
 
    }
}
