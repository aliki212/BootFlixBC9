using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using System.ComponentModel.DataAnnotations;
using BootFlixBC9.ViewModels;

namespace BootFlixBC9.Controllers
{
    public class SerieController : Controller
    {
        
        private IEnumerable<Serie> GetSeries()
        {
            return new List<Serie>
            {
                new Serie { Id = 1, Name = "Lost"},
                new Serie { Id = 2, Name = "Game of Thrones"}
            };
        }
        public ActionResult Index()
        {
            var series = GetSeries();
            return View(series);
        }
        // GET: Serie/Perfect
        public ActionResult Perfect()
        {
            var serie = new Serie()
            {
                Name = "The Wire"
            };
            var viewers = new List<Viewer>
            {
                new Viewer { Name = "Peri Aidino"},
                new Viewer { Name = "Chris Antonopoulos"}
            };

            var viewModel = new PerfectSerieViewModel
            {
                Serie = serie,
                Viewers = viewers
            };

            return View(viewModel);
        }

        [Route("serie/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year +"/" + month);
        }
    }
}