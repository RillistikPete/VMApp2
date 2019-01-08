using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VMApp2.Models;

namespace VMApp2.Views.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}