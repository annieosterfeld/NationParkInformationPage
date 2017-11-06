using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Dal
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString;
        private const string getAllSurveysSql = "select COUNT(survey_result.parkCode) AS Votes , survey_result.parkCode, park.parkName FROM survey_result JOIN park ON survey_result.parkCode = park.parkCode GROUP BY survey_result.parkCode, park.parkName ORDER BY Votes DESC";
        private const string saveNewSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel)";
        private const string getParkNames = "SELECT parkCode, parkName FROM park";

        public SurveySqlDAL(string dbCOnnectionString)
        {
            connectionString = dbCOnnectionString;
        }
        public List<Survey> GetAllSurveys()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(getAllSurveysSql, conn);
                SqlDataReader results = command.ExecuteReader();
                List<Survey> surveys = new List<Survey>();
                while(results.Read())
                {
                    Survey survey = new Survey();
                    //survey.SurveyId = Convert.ToInt32(results["surveyId"]);
                    survey.ParkCode = Convert.ToString(results["parkCode"]);
                    survey.Votes = Convert.ToInt32(results["Votes"]);
                    survey.ParkName = Convert.ToString(results["parkName"]);
                    //survey.Email = Convert.ToString(results["emailAddress"]);
                    //survey.State = Convert.ToString(results["state"]);
                    //survey.ActivityLevel = Convert.ToString(results["activityLevel"]);
                    surveys.Add(survey);
                }
                return surveys;
            }
        }
        public bool SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(saveNewSurvey, conn);
                    command.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    command.Parameters.AddWithValue("@emailAddress", survey.Email);
                    command.Parameters.AddWithValue("@state", survey.State);
                    command.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    int rowAffected = command.ExecuteNonQuery();
                    return (rowAffected > 0);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public List<ParkWeather> Parks()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(getParkNames, conn);
                SqlDataReader results = command.ExecuteReader();
                List<ParkWeather> parks = new List<ParkWeather>();
                while (results.Read())
                {
                    ParkWeather park = new ParkWeather();
                    park.ParkName = Convert.ToString(results["parkName"]);
                    park.ParkCode = Convert.ToString(results["parkCode"]);
                    parks.Add(park);
                }
                return parks;
            }
        }
    }
}