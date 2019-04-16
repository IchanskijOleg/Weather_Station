using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    public class DAOWeather
    {
        SqlConnection conn;
        public DAOWeather(string conn_name)
        {
            string connStr = ConfigurationManager.ConnectionStrings[conn_name].ConnectionString;
            conn = new SqlConnection(connStr);
        }
        public void PrintConnectionInfo()
        {
            conn.Open();
            // Вывод информации о подключении
            Console.WriteLine("Свойства подключения:");
            Console.WriteLine("\tСтрока подключения: {0}", conn.ConnectionString);
            Console.WriteLine("\tБаза данных: {0}", conn.Database);
            Console.WriteLine("\tСервер: {0}", conn.DataSource);
            Console.WriteLine("\tВерсия сервера: {0}", conn.ServerVersion);
            Console.WriteLine("\tСостояние: {0}", conn.State);
            Console.WriteLine("\tWorkstationld: {0}", conn.WorkstationId);
            conn.Close();
        }
        public void Insert(DateTime wheaterDate, int temperature, int wind, int cloudiness, int regionId)
        {
            conn.Open();

            string sqlInsert = $"INSERT INTO Wheater(wheaterDate,temperature,wind,cloudiness,regionId) VALUES('{wheaterDate}',{temperature},{wind},{cloudiness},{regionId}))";
            SqlCommand command = new SqlCommand(sqlInsert, conn);
            Console.WriteLine("К-во вставок =" + command.ExecuteNonQuery());
            conn.Close();
        }
        public void Delete(DateTime wheaterDate, int regionId)
        {
            //[Wheater] ([wheaterDate], [temperature], [wind], [cloudiness], [regionId]
            conn.Open();
            string sqlDelete = $"DELETE FROM Wheater WHERE wheaterDate= '{wheaterDate}' AND regionId= {regionId}";
            SqlCommand command = new SqlCommand(sqlDelete, conn);
            Console.WriteLine("К-во удалений =" + command.ExecuteNonQuery());
            conn.Close();
        }
        //public void FillBusFromDB(List<WeatherCity> data)
        //{
        //    conn.Open();
        //    string sqlSelect = $"select * from Wheater";
        //    SqlCommand command = new SqlCommand(sqlSelect, conn);
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            City = city;
        //            CelsiusCurrent = celsiusCurrent;
        //            SpeedMetersPerSecond = speedMetersPerSecond;
        //            Clouds = clouds;

        //            data.Add(new WeatherCity(Convert.ToInt32(reader["id"]),
        //                             Convert.ToString(reader["name"]),
        //                             Convert.ToInt32(reader["route"]))
        //                    );
        //        }
        //    }
        //    conn.Close();
        //}
        public void Show()
        {
            conn.Open();
            string sqlSelect = $"select * from Wheater";
            SqlCommand command = new SqlCommand(sqlSelect, conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader.GetName(i) + "\t");
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader[i] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            conn.Close();
        }
    }
}
