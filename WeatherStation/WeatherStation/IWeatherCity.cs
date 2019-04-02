using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    public interface IWeatherCity
    {
        string City { get; set; }
        double CelsiusCurrent { get; set; }
        double SpeedMetersPerSecond { get; set; }
        double Clouds { get; set; }
    }
}
