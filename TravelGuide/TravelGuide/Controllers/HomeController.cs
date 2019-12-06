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
            if (User.Identity.GetUserId() == null)
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
            Itinerary itinerary = new Itinerary();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SearchForThings(Itinerary itinerary)
        {

            string id = User.Identity.GetUserId();
            var user = context.Customers.Where(u => u.ApplicationId == id).FirstOrDefault();
            string url = $"https://google-search1.p.rapidapi.com/google-search?keywords={itinerary.ItineraryName}&hl=en&gl=us";

            //var client = new RestClient(url);
            // "https://google-search1.p.rapidapi.com/google-search?q=Avengers%252BEndgame&hl=en&gl=us"

            //var request = new RestRequest(Method.GET);
            //request.AddHeader("x-rapidapi-host", "google-search1.p.rapidapi.com");
            //request.AddHeader("x-rapidapi-key", "140d239612msh901de9fc0c6b784p1f0effjsned3b86971ce8");
            //IRestResponse response = client.Execute(request);


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "140d239612msh901de9fc0c6b784p1f0effjsned3b86971ce8");
            HttpResponseMessage response = await client.GetAsync(url);

            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)

            {
                SearchItem searchedItem = JsonConvert.DeserializeObject<SearchItem>(data);

                //var jsonResults = JsonConvert.DeserializeObject(data);
                //Class1 c1 = new Class1();

                // how to access data in json
                //c1.title = jsonResult.organic[0].title;

                

                return View("SearchResults", searchedItem);
            }

            return View("SearchResults", "Home");
        }

        public ActionResult SearchResults(SearchItem searchedItem)
        {
            return View(searchedItem);
        }

    }
}