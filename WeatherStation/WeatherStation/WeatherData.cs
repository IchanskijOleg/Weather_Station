using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherData
    {
        private WeatherCity weather;
        protected Action<WeatherCity> observers = null;

        public event Action<WeatherCity> EventWeather
        {
            add { observers += value; }
            remove { observers -= value; }
        }

        public void SetMeasuremants(WeatherCity weather)
        {
            this.weather = weather;
        }

        public void Notify()
        {
            observers.Invoke(weather);
        }
    }
}
