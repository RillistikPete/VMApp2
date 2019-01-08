﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMApp2.Models;

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


        // GET: Customer
        public ActionResult Index()
        {
            // var customers = GetCustomers();  WITHOUT DATABASE
            var customers = _context.Customers;

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            //query is now immediately executed with SingleOrDefault()
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

    }
}