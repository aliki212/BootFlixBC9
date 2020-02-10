using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using System.ComponentModel.DataAnnotations;
using BootFlixBC9.ViewModels;
using BootFlixBC9.MockRepositories;

namespace BootFlixBC9.Controllers
{
    public class SerieController : Controller
    {
        private readonly MockSerieRepository _mockSerieRepository = new MockSerieRepository();
        
        public ActionResult Index()
        {
            var series = _mockSerieRepository.GetSeries();
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