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
                //initialize customer here so that 'Id field is required' is not included in validation summary
                Customer = new Customer(),
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
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // Malicious users can modify request data and add key/val pairs with the TryUpdateModel approach:
                // and the work-around suggested by Microsoft says you can Whiteley's the properties to be updated
                // using the third argument (string array of props to be updated), but if you rename them, code will break.
                // TryUpdateModel(customerInDb, "", new string[]{"Name", "Email"});
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
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