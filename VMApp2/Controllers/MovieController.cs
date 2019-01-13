using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMApp2.Models;
using VMApp2.Views.ViewModels;
using System.Data.Entity;

namespace VMApp2.Controllers
{
    public class MovieController : Controller
    {
        //Instantiate Database call
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ActionResult Index()
        {
            //Need System.Data.Entity for m.Genre via Eager Loading
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == m.Id);

            if(movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //if (!pageIndex.HasValue)
        //    pageIndex = 1;
        //if (String.IsNullOrWhiteSpace(sortBy))
        //    sortBy = "Name";
        //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        //    return View();
        //}

        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>();
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }


        [Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}