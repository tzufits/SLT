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
        [Required]
        [Display(Name = "יום")]
        public string Day { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "עיר")]
        public string City { get; set; }

        [Display(Name = "מין")]
        public bool Sex { get; set; }
    }
}
