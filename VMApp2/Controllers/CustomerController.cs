using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMApp2.Models;
using VMApp2.ViewModels;

namespace VMApp2.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //DbContext is a disposable object, so we need to properly dispose of it:
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var memTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = memTypes
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customer
        public ActionResult Index()
        {
            // var customers = GetCustomers();  WITHOUT DATABASE
            //Need System.Data.Entity for c.MembershipType via Eager Loading
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            //query is now immediately executed with SingleOrDefault()
            // Eager loading of MemberhsipType via .Include()
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        // Model-binding: this model is bound to request data
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var memType = _context.MembershipTypes.ToList();

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = memType
                //can also condense code with:
                //MembershipTypes = _context.MembershipTypes.ToList();
            };

            return View("CustomerForm", viewModel);
        }

    }
}