using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using BootFlixBC9.MockRepositories;

namespace BootFlixBC9.Controllers
{
    public class ViewerController : Controller
    {
        private readonly MockViewerRepository _mockViewerRepository = new MockViewerRepository();
        // GET: Viewer
        public ActionResult Index()
        {
            var viewers = _mockViewerRepository.GetViewers();
            return View(viewers);
        }
        
        public ActionResult Details(int id)
        {
            var viewer = _mockViewerRepository.GetViewers().SingleOrDefault(v => v.Id == id);
            if (viewer == null)
                return HttpNotFound();

            return View(viewer);
        }
    }
}