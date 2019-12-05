using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelGuide.Models
{
    public class GoogleSearch
    {
        public Class1[] Property1 { get; set; }

    }

    public class Class1
    {
        public string keyword { get; set; }

        [Display(Name = "Total Results")]
        public int totalResults { get; set; }

        public string url { get; set; }

        public string title { get; set; }
    }
}