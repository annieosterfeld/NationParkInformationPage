using Capstone.Web.Dal;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        private string connectionString = ConfigurationManager.ConnectionStrings["ParkWeatherDb"].ConnectionString;

        public SurveyController()
        {
            surveyDAL = new SurveySqlDAL(connectionString);
        }

        public ActionResult TakeSurvey()
        {
            Survey survey = new Survey();
            ParkWeatherSqlDal parkDAL = new ParkWeatherSqlDal(connectionString);
            survey.Parks = parkDAL.GetAllParks();
            return View(survey);
        }
        [HttpPost]
        public ActionResult TakeSurvey(Survey survey)
        {
            if(!ModelState.IsValid)
            {
                ParkWeatherSqlDal parkDAL = new ParkWeatherSqlDal(connectionString);
                survey.Parks = parkDAL.GetAllParks();
                return View("TakeSurvey", survey);
            }
            else
            {
                surveyDAL.SaveNewSurvey(survey);
                return RedirectToAction("TakeSurveyResult", "Survey");
            }
        }
        public ActionResult TakeSurveyResult()
        {

            List<Survey> allSurveys = surveyDAL.GetAllSurveys();
            return View(allSurveys);
        }
    }
}