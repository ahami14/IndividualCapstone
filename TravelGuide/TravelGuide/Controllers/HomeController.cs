using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        public HomeController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if(User.Identity.GetUserId() == null)
            {
                return View();
            }
            else
            {
                string userId = User.Identity.GetUserId();
                var user = context.Customers.Where(c => c.ApplicationId == userId).FirstOrDefault();
                return RedirectToAction("Details", "Customers", new { id = user.CustomerId });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchForPlaces()
        {
            ViewBag.Message = "Search for Places";
            return View();
        }

        public ActionResult SearchResults()
        {
            return View();
        }

        public ActionResult SearchForThings()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(/*ItemInItinerary item*/)
        {

            string id = User.Identity.GetUserId();
            var user = context.Customers.Where(u => u.ApplicationId == id).FirstOrDefault();
            string url = $"https://google-search1.p.rapidapi.com/google-search";

            var client = new RestClient("https://google-search1.p.rapidapi.com/google-search?q=Avengers%252BEndgame&hl=en&gl=us");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "google-search1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "140d239612msh901de9fc0c6b784p1f0effjsned3b86971ce8");
            IRestResponse response = client.Execute(request);


            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "140d239612msh901de9fc0c6b784p1f0effjsned3b86971ce8");
            //HttpResponseMessage response = await client.GetAsync(url

            string data = response.Content.ToString();
            //if (response.IsSuccessStatusCode)
            if (response.StatusCode == System.Net.HttpStatusCode.OK)

            {
                var test = JsonConvert.DeserializeObject(data);

                return View("SearchResults", test);
            }

            return View("SearchResults", "Home");
        }

        //    public ActionResult SearchResults(Class2[] events)
        //    {
        //        return View(events);
        //    }

        //search input from user (form)
        //API method is POST from the form and take in a string for the URL
        //make google model, test to get data out
    }
}