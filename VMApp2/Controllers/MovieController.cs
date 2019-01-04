using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Views.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
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
            var movies = GetMovies();

            return View(movies);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie {Id=1, Name="Anchorman" },
                new Movie {Id=2, Name="Step Brothers"}
            };

        }

        [Route("movie/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }
    }
}