using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using System.ComponentModel.DataAnnotations;
using BootFlixBC9.ViewModels;
using BootFlixBC9.MockRepositories;
using System.Data.Entity;

namespace BootFlixBC9.Controllers
{
    public class SerieController : Controller
    {
        //private readonly MockSerieRepository _mockSerieRepository = new MockSerieRepository();

        private ApplicationDbContext context;
        //part2
        public SerieController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Series
        public ViewResult Index()
        {
            var series = context.Series
                .Include(v => v.Genre)
                .ToList();
            return View(series);
        }
        
        public ActionResult Details(int id)
        {
            var serie = context.Series
                .Include(s => s.Genre).SingleOrDefault(s => s.Id == id);
            if (serie==null)
                return HttpNotFound();

            return View(serie);
        }

        public ActionResult Edit(int Id)
        {
            var serie = context.Series.SingleOrDefault(s => s.Id == Id);
            if (serie == null)
                return HttpNotFound();
            var viewModel = new SerieFormVIewModel
            {
                Serie = serie,
                Genres = context.Genres.ToList()
            };

            return View("SerieForm",viewModel);
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