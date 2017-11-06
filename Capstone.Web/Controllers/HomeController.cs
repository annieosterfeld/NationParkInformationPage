using Capstone.Web.Dal;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IParkWeatherDal applicationDal;

        public HomeController(IParkWeatherDal applicationDal)
        {
            this.applicationDal = applicationDal;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("Index", applicationDal.GetAllParks());
        }

        //GET: Park Details
        //Session decides how the temp is rendered
        public ActionResult ParkDetail(string id, string degreeType)
        {
            if (Session["degreeType"] == null)
            {
                Session["degreeType"] = "F";
                
            }
            else if (degreeType == "C" || degreeType == "F")
            {
                Session["degreeType"] = degreeType;
            }

            ViewData["degreeType"] = (string)Session["degreeType"];

            List<ParkWeather> parksList = applicationDal.GetAllParks();
            List<ParkWeather> holdingList = new List<ParkWeather>();
            foreach (ParkWeather element in parksList)
            {
                if (element.ParkCode == id)
                {
                    holdingList.Add(element);
                }
            }
            return View("ParkDetail", holdingList);
        }
    }
}