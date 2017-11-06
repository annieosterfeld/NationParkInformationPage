using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Dal;
using Capstone.Web.Models;
using System.Data.SqlClient;
using System.Transactions;
using System.Collections.Generic;

namespace Capstone.Web.Tests.DalTests
{
    [TestClass()]
    public class ParkWeatherDalTest
    {
        private const string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=ParkWeather;Integrated Security=True";
        private TransactionScope tran;
        private int parkCount;
        [TestInitialize]
        public void ParkWeatherTestSet()
        {
            tran = new TransactionScope();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("SELECT COUNT(*) FROM park JOIN weather ON weather.parkCode = park.parkCode", conn);
                parkCount = (int)cmd.ExecuteScalar();
            }
        }
        [TestCleanup]
        public void CleanUp()
        {
            tran.Dispose();
        }


        [TestMethod]
        public void GetAllParksTest()
        {
            ParkWeatherSqlDal testDal = new ParkWeatherSqlDal(connectionString);
            List<ParkWeather> testList = testDal.GetAllParks();

            Assert.AreEqual(parkCount, testList.Count);
        }
    }
}

