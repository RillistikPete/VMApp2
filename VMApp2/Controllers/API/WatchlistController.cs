using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VMApp2.DTOs;
using VMApp2.Models;

namespace VMApp2.Controllers.API
{
    public class WatchlistController : ApiController
    {
        private ApplicationDbContext _context;

        public WatchlistController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateWatchlist(WatchlistMovieDTO watchlistDTO)
        {
            if (watchlistDTO.MovieIds.Count == 0)
                return BadRequest("No Movie Id's have been given.");

            var customer = _context.Customers.Single(c => c.Id == watchlistDTO.CustomerId);

            var movies = _context.Movies.Where(m => watchlistDTO.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != watchlistDTO.MovieIds.Count)
                return BadRequest("One or more movie id's are invalid.");

            foreach(var movie in movies)
            {
                movie.HasBeenWatched = false;
                var watchlistItem = new WatchlistMovie
                {
                    Customer = customer,
                    Movie = movie,
                    DateAdded = DateTime.Now,
                };
                _context.Watchlist.Add(watchlistItem);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
