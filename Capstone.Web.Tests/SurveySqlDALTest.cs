using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Models;
using Capstone.Web.Dal;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace Capstone.Web.Tests
{
    [TestClass()]
    public class SurveySqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ParkWeather;Integrated Security=True";
        private int surveys;
        private int surveyId;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command;
                conn.Open();
                //command = new SqlCommand("INSERT INTO survey_result VALUES ('GNP', 'annieoster@wowway.com', 'OH', 'active')", conn);
                //surveyId = (int)command.ExecuteScalar();

                command = new SqlCommand("SELECT COUNT(*) FROM survey_result", conn);
                surveys = (int)command.ExecuteScalar();

            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            tran.Dispose();
        }
        [TestMethod]
        public void GetAllSurveysTest()
        {
            SurveySqlDAL surveyDAL = new SurveySqlDAL(connectionString);
            List<Survey> surveyList = surveyDAL.GetAllSurveys();

            Assert.IsNotNull(surveyList);
            Assert.AreEqual(surveys, surveyList.Count);
        }
        [TestMethod]
        public void SaveNewSurveyTest()
        {
            SurveySqlDAL surveyDAL = new SurveySqlDAL(connectionString);
            Survey testSurvey = new Survey()
            {
                SurveyId = surveyId,
            };
            Assert.AreEqual(true, surveyDAL.SaveNewSurvey(testSurvey));
        }
    }
}
