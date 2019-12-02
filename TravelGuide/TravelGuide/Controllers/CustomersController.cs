using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Models;

namespace TravelGuide.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext context;
        public CustomersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = context.Customers;
            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {

            Customer customer = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();
                customer.ApplicationId = id;
                context.Customers.Add(customer);
                context.SaveChanges();

                

                return View("Details", customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer customer1 = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
                customer1.FirstName = customer.FirstName;
                customer1.LastName = customer.LastName;
                customer1.StreetAddress = customer.StreetAddress;
                customer1.PhoneNumber = customer.PhoneNumber;
                customer1.Insterests = customer.Insterests;

                context.SaveChanges();


                return RedirectToAction("Details", "Customers", customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                Customer customerToDelete = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
                context.Customers.Remove(customerToDelete);
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
