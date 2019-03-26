using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherData: IObserverable
    {
        List<IObsorver<WeatherCity>> masWeather;
        private WeatherCity weather;

        public WeatherData()
        {
            masWeather = new List<IObsorver<WeatherCity>>();
        }

        public void Register(IObsorver<WeatherCity> obs)
        {
            masWeather.Add(obs);
        }

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
    }
}
