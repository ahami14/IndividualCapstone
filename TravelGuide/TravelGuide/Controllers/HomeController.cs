using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
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
            ViewBag.Message = "Maps and Places API in Progress";
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


        public async Task<ActionResult> Search(ItemInItinerary item)
        {

            string id = User.Identity.GetUserId();
            var user = context.Customers.Where(u => u.ApplicationId == id).FirstOrDefault();
            string url = $"https://www.eventbriteapi.com/v3/events/search?location.address&keywords={item.LocationOfEvent}";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "GIXJAFBFW3JE4F7VD4");
            HttpResponseMessage response = await client.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Class2[] events = JsonConvert.DeserializeObject<Class2[]>(data);

                return View("SearchResults", events);
            }

                return View("SearchResults", "Home");
        }

        public ActionResult SearchResults(Class2[] events)
        {
            return View(events);
        }
    }
}