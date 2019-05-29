using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMApp2.Models
{
    public class WatchlistMovie
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public Movie Movie { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateCompleted { get; set; }

    }
}