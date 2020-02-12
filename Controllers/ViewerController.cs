using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using BootFlixBC9.MockRepositories;
using System.Data.Entity;

namespace BootFlixBC9.Controllers
{
    public class ViewerController : Controller
    {
        //private readonly MockViewerRepository _mockViewerRepository = new MockViewerRepository();
       //Just another way to break down and continue the createion of context object
       //part1
        private ApplicationDbContext context;
        //part2
        public ViewerController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Viewer
        public ActionResult Index()
        {
            var viewers = context.Viewers
                .Include(v => v.MembershipType)
                .ToList();
            return View(viewers);
        }
        
        public ActionResult Details(int id)
        {
            var viewer = context.Viewers
                .Include(c=> c.MembershipType) //added for bringing the new name of Membership - eskage as null b4
                .SingleOrDefault(v => v.Id == id);
            if (viewer == null)
                return HttpNotFound();

            return View(viewer);
        }
    }
}