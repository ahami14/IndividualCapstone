using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelGuide.Models
{
    public class Hotel
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        [Display(Name = "City")]
        public string city { get; set; }
    }
}