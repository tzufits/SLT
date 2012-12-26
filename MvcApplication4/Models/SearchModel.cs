using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace SLT.Models
{
    public class SearchModel
    {
        [Display(Name = "שם פרטי ")]
        public string First { get; set; }

        [Display(Name = "שם משפחה: ")]
        public string Last { get; set; }


        [Display(Name = "יום  ")]
        public string Day { get; set; }

        [Display(Name = "שעה ")]
        public string Hour { get; set; }

        [Display(Name = "אזור ")]
        public string City { get; set; }

        [Display(Name = "מין  ")]
        public string Sex { get; set; }

        [Display(Name = "זכר ")]
        public bool Male { get; set; }
        
        [Display(Name = "נקבה ")]
        public bool Female { get; set; }


    }
}