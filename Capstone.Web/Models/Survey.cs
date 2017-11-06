using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {

        public int SurveyId { get; set; }

        [Required]
        public string ParkCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        public int Votes { get; set; }

        public string ParkName { get; set; }

        public List<ParkWeather> Parks { get; set; }


        public static List<SelectListItem> Activities { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Inactive", Value = "inactive"},
            new SelectListItem() {Text = "Sedentary", Value = "sedentary"},
            new SelectListItem() {Text = "Active", Value = "active"},
            new SelectListItem() {Text = "Extremely Active", Value = "extremely active"}
        };
        
    }
}