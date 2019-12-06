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
        public SearchItem search { get; set; }
    }

    public class SearchItem
    {
        public int currentPage { get; set; }
        public string keyword { get; set; }
        public Organic[] organic { get; set; }
        public Pagination[] pagination { get; set; }
        public object[] relatedKeywords { get; set; }
        public int totalResults { get; set; }
        public float timeTaken { get; set; }
    }

    public class Organic
    {
        public string domain { get; set; }
        public string linkType { get; set; }
        public int position { get; set; }
        public string snippet { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string cachedUrl { get; set; }
    }

    public class Pagination
    {
        public int page { get; set; }
        public string path { get; set; }
    }

}