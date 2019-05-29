using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMApp2.DTOs
{
    public class WatchlistMovieDTO
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}