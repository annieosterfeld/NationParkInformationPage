using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Web.Dal
{
    interface ISurveyDAL
    {
        List<Survey> GetAllSurveys();
        bool SaveNewSurvey(Survey survey);
        List<ParkWeather> Parks();
    }
}
