using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherStation
{
    public class WeatherCreator
    {
        List<IWeatherCity> mas = new List<IWeatherCity>();
        public IWeatherCity weatherCity;
        public void CreateWeatheFromFile(IWeatherCity weatherCity)
        {
            this.weatherCity = weatherCity;
        }

        public void SaveToFile(IWeatherCity weatherCity, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(weatherCity.ToFile());
            }
        }

        public List<IWeatherCity> ReadFromFile(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    //int type = int.Parse(sr.ReadLine());
                    string strparams = sr.ReadLine();
                    string[] p = strparams.Split('=');

                    if (this.weatherCity == null)
                        this.weatherCity = new WeatherCity();

                    switch (p[0])
                    {
                        case "City":
                            weatherCity.City = p[1].ToString();
                            break;
                        case "CelsiusCurrent":
                            weatherCity.CelsiusCurrent = double.Parse(p[1]);
                            break;
                        case "SpeedMetersPerSecond":
                            weatherCity.SpeedMetersPerSecond = double.Parse(p[1]);
                            break;
                        case "Clouds":
                            weatherCity.Clouds = double.Parse(p[1]);
                            if (p[1] != null)
                                mas.Add(weatherCity);
                            break;
                    }
                }
                return mas;
            }
        }

    }
}
