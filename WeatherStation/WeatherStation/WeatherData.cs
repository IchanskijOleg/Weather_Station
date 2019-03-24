using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherData: IObserverable
    {
        List<IObsorver<WeatherCity>> masWeather = new List<IObsorver<WeatherCity>>();
        private WeatherCity weather;

        public void Delete(IObsorver<WeatherCity> obs)
        {
            masWeather.Remove(obs);
        }

        public void Notify()
        {
            foreach (var item in masWeather)
            {
                item.Update(weather);
            }
        }

        public void Register(IObsorver<WeatherCity> obs)
        {
            masWeather.Add(obs);
        }

        public void MeasurementChanged(WeatherCity weather)
        {
            this.weather = weather;
            Notify();
        }
    }
}
