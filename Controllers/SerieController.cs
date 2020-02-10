using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using System.ComponentModel.DataAnnotations;

namespace BootFlixBC9.Controllers
{
    public class SerieController : Controller
    {
        // GET: Serie/Perfect
        public ActionResult Perfect()
        {
            var serie = new Serie()
            {
                Name = "The Wire"
            };
            return View(serie);
        }

        [Route("serie/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/" + month);
        }
    }
}