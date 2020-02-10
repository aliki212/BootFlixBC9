using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;

namespace BootFlixBC9.Controllers
{
    public class ViewerController : Controller
    {
        private IEnumerable<Viewer> GetViewers()
        {
            return new List<Viewer>
            {
                new Viewer { Id = 1 , Name = "Costas Spyrou"},
                new Viewer { Id = 2 , Name = "Pavlina Kostalea"}
            };
        }
        // GET: Viewer
        public ActionResult Index()
        {
            var viewers = GetViewers();
            return View(viewers);
        }
        
        public ActionResult Details(int id)
        {
            var viewer = GetViewers().SingleOrDefault(v => v.Id == id);
            if (viewer == null)
                return HttpNotFound();

            return View(viewer);
        }
    }
}