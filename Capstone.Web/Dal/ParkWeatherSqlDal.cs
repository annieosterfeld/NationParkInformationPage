using Capstone.Web.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;


namespace Capstone.Web.Dal

{
    public class ParkWeatherSqlDal : IParkWeatherDal
    {
       private readonly string connectionString;
        private const string getAllParksSql = "SELECT * FROM park JOIN weather ON park.parkCode = weather.parkCode;";

        public ParkWeatherSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public int TestMethod()
        {
            return 0;
        }

        public List<ParkWeather> GetAllParks()
        {
            List<ParkWeather> allParkWeathers = new List<ParkWeather>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getAllParksSql, conn);
                SqlDataReader reader =  cmd.ExecuteReader();
                while (reader.Read())
                {
                    ParkWeather pw = new ParkWeather();
                    pw.Acreage = Convert.ToInt32(reader["acreage"]);
                    pw.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                    pw.Climate = Convert.ToString(reader["climate"]);
                    pw.ElevationInFeet = Convert.ToInt32(reader["elevationInFeet"]);
                    pw.EntryFee = Convert.ToInt32(reader["entryFee"]);
                    pw.FiveDayForcastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                    pw.Forecast = Convert.ToString(reader["forecast"]);
                    pw.High = Convert.ToInt32(reader["high"]);
                    pw.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                    pw.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                    pw.Low = Convert.ToInt32(reader["low"]);
                    pw.MilesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                    pw.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                    pw.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                    pw.ParkCode = Convert.ToString(reader["parkCode"]);
                    pw.ParkDescription = Convert.ToString(reader["parkDescription"]);
                    pw.ParkName = Convert.ToString(reader["parkName"]);
                    pw.State = Convert.ToString(reader["state"]);
                    pw.YearFounded = Convert.ToInt32(reader["yearFounded"]);

                    allParkWeathers.Add(pw);

                }

            }
            return allParkWeathers;
        }
    }
}

