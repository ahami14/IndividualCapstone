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
                return RedirectToAction("Details", "Customers", user);
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

        public ActionResult Search()
        {
            ViewBag.Message = "Maps and Places API in Progress";
            return View();
        }


        public async Task<ActionResult> SearchForHotels(ItemInItinerary item)
        {

            string id = User.Identity.GetUserId();
            var user = context.Customers.Where(u => u.ApplicationId == id).FirstOrDefault();
            string url = $"https://google-search1.p.rapidapi.com/google-search?keywords={item.LocationOfEvent}&hl=en&gl=us";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "140d239612msh901de9fc0c6b784p1f0effjsned3b86971ce8");
            HttpResponseMessage response = await client.GetAsync(url);
            string data = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Class1[] hotels = JsonConvert.DeserializeObject<Class1[]>(data);

                return View("Search", hotels);
            }

                return View("Search", "Home");
        }

        public ActionResult SearchResults(Class1[] hotels)
        {
            return View(hotels);
        }
    }
}