using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WeatherStation
{
    public static class СWriteLog
    {
        //public static string path = @"D:\WeatherStation.txt";
        public static string path = @"C:\Users\o.ichanskij\Documents\WeatherStation.txt";
        public static string dateString = DateTime.Now.ToString();

        public static void WriteFile(string text)
        {
            StreamWriter sw = new StreamWriter(path, true);
            if (dateString != null)
            {
                sw.WriteLine();
                sw.WriteLine(dateString);
            }
            sw.WriteLine(text);
            dateString = null;
            sw.Close();
        }
    }
}
