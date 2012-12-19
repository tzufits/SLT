using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication4.Models
{
    public class SearchModel
    {

        [Display(Name = "יום  ")]
        public string Day { get; set; }


        [Display(Name = "עיר  ")]
        public string City { get; set; }

        [Display(Name = "מין  ")]
        public string Sex { get; set; }

        [Display(Name = "זכר ")]
        public bool Mail { get; set; }

        [Display(Name = "נקבה ")]
        public bool Femail { get; set; }
    }
}
