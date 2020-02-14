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

            var viewModel = new SerieFormViewModel
            {
                Id = serie.Id,
                Name = serie.Name,
                DateReleased = serie.DateReleased,
                Seasons = serie.Seasons,
                GenreId = serie.GenreId,
                Genres = context.Genres.ToList(),
                //Title = "Edit Series"
            };

            return View("SerieForm",viewModel);
        }

        //GET NEW - getting the data to present to input the data and then post them //copy from ViewerController
        public ActionResult New() // WAS NEW
        {
            var genres = context.Genres.ToList();
            var viewmodel = new SerieFormViewModel()
            {
                Genres = genres,
                // 2 // set the serie new object so id is not null when creating as we saw in viewers
                Serie = new Serie(),
                //Title = "Add a New Series"
            };

            return View("SerieForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Serie serie)
        {
            // 1 // worst case scenario return the viewmodel with the list of genres
            if (!ModelState.IsValid)
            {
                var genres = context.Genres.ToList();
                var viewModel = new SerieFormViewModel()
                {
                    Genres = genres,
                    //Title = "Add a New Series"
                };

                return View("ViewerForm", viewModel);
            }

            if (serie.Id == 0) //meanst the viewer coming back is without id = then go create one!
            {
                //Very cool and simple way to register the new creation
                serie.DateAdded = DateTime.Now;
                context.Series.Add(serie);
            }
            else
            {
                var serieDb = context.Series.Single(v => v.Id == serie.Id);
                
                serieDb.Name = serie.Name;
                serieDb.GenreId = serie.GenreId;
                serieDb.Seasons = serie.Seasons;
                serieDb.DateReleased = serie.DateReleased;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Serie");
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