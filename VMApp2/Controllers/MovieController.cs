using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMApp2.Models;
using VMApp2.Views.ViewModels;

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

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
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

        public ActionResult Index()
        {
            //Need System.Data.Entity for m.Genre via Eager Loading
            var movies = _context.Movies.Include(m => m.GenreId);

            return View(movies);
        }



        [Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}