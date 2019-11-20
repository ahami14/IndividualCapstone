using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class ItemsController : Controller
    {
        ApplicationDbContext context;
        public ItemsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Items
        public ActionResult Index()
        {
            var items = context.Items;
            return View(items);
        }

        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            ItemInItinerary item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ItemInItinerary item = new ItemInItinerary();
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        public ActionResult Create(ItemInItinerary item)
        {
            try
            {
                // TODO: Add insert logic here
                context.Items.Add(item);
                context.SaveChanges();
                var itinerary = context.Itineraries.Where(i => i.ItineraryId == item.ItemId).FirstOrDefault();
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            ItemInItinerary item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemInItinerary item)
        {
            try
            {
                // TODO: Add update logic here
                ItemInItinerary itemToEdit = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
                itemToEdit.DateOfEvent = item.DateOfEvent;
                itemToEdit.DetailsOfEvent = item.DetailsOfEvent;
                itemToEdit.EventName = item.EventName;
                itemToEdit.LocationOfEvent = item.LocationOfEvent;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            ItemInItinerary item = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ItemInItinerary item)
        {
            try
            {
                // TODO: Add delete logic here
                ItemInItinerary itemToDelete = context.Items.Where(i => i.ItemId == id).FirstOrDefault();
                context.Items.Remove(itemToDelete);
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
