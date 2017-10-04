using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using SmartMonitoring.BBDD;

namespace SmartMonitoring.Droid
{
    public class SQLAndroid
    {
        SQLiteConnection connection;
        public SQLiteConnection GetConnection()
        {
            var fileName = "SmartMonitoring.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            connection = new SQLiteConnection(path);
            if (connection != null)
            {
                initBBDD();
            }
            return connection;
        }

        //Estos métodos hay que ver en que clase deberían ir

        public void initBBDD()
        {
            connection.CreateTable<RPMData>();
            connection.CreateTable<DTCData>();
            connection.CreateTable<EngineTemperatureData>();
            connection.CreateTable<FuelPressure>();
            connection.CreateTable<SpeedData>();
            connection.CreateTable<ThrottlePosition>();
        }
    }
}