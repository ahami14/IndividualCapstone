using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class ItineraryController : Controller
    {
        ApplicationDbContext context;
        public ItineraryController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Itinerary
        public ActionResult Index()
        {
            var itineraries = context.Itineraries;
            return View(itineraries);
        }

        // GET: Itinerary/Details/5
        public ActionResult Details(int id)
        {
            Itinerary itinerary = context.Itineraries.Where(i => i.ItineraryId == id).FirstOrDefault();
            return View(itinerary);
        }

        // GET: Itinerary/Create
        public ActionResult Create()
        {
            Itinerary itinerary = new Itinerary();
            return View();
        }

        // POST: Itinerary/Create
        [HttpPost]
        public ActionResult Create(Itinerary itinerary)
        {
            try
            {
                // TODO: Add insert logic here
                context.Itineraries.Add(itinerary);
                context.SaveChanges();
                string id = User.Identity.GetUserId();
                var user = context.Customers.Where(u => u.ApplicationId == id).FirstOrDefault();
                itinerary.ItineraryId = user.CustomerId;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Itinerary/Edit/5
        public ActionResult Edit(int id)
        {
            Itinerary itinerary = context.Itineraries.Where(i => i.ItineraryId == id).FirstOrDefault();
            return View(itinerary);
        }

        // POST: Itinerary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Itinerary itinerary)
        {
            try
            {
                // TODO: Add update logic here
                Itinerary editItinerary = context.Itineraries.Where(i => i.ItineraryId == id).FirstOrDefault();
                editItinerary.ItineraryName = itinerary.ItineraryName;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Itinerary/Delete/5
        public ActionResult Delete(int id)
        {
            Itinerary itinerary = context.Itineraries.Where(i => i.ItineraryId == id).FirstOrDefault();
            return View(itinerary);
        }

        // POST: Itinerary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Itinerary itinerary)
        {
            try
            {
                // TODO: Add delete logic here
                Itinerary itineraryToDelete = context.Itineraries.Where(i => i.ItineraryId == id).FirstOrDefault();
                context.Itineraries.Remove(itineraryToDelete);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
