using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VMApp2.Controllers
{
    public class WatchlistController : Controller
    {
        public ActionResult New()
        {
            return View("NewWatchlistMovie");
        }
    }
}