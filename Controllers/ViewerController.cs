using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootFlixBC9.Models;
using BootFlixBC9.MockRepositories;
using System.Data.Entity;
using BootFlixBC9.ViewModels;

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
        //GET NEW - getting the data to present to input the data and then post them
        public ActionResult New() // WAS NEW
        {
            var membershiptypes = context.MembershipTypes.ToList();
            var viewmodel = new ViewerFormViewModel()
            {
                MembershipTypes = membershiptypes
            };
           
            return View("ViewerForm", viewmodel);
        }

        //POST
        [HttpPost]
        public ActionResult Save(Viewer viewer)
        {

            if(viewer.Id == 0) //meanst the viewer coming back is without id = then go create one!
            context.Viewers.Add(viewer);
            else
            {
                var viewerDb = context.Viewers.Single(v => v.Id == viewer.Id);
                //TryUpdateModel string [] whitelist
                //instead of using whitelist to update a model - we are going to update every
                //single property since with whitelist is a magic string with no control
                viewerDb.Name = viewer.Name;
                viewerDb.Birtdate = viewer.Birtdate;
                viewerDb.MembershipTypeId = viewer.MembershipTypeId;
                viewerDb.IsSubscribedToNews = viewer.IsSubscribedToNews;
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Viewer");
        }

        //GET EDIT - substituting Details link in Viewer Index View
        public ActionResult Edit(int id)
        {
            var viewer = context.Viewers.SingleOrDefault(v => v.Id == id);

            if (viewer == null)
                return HttpNotFound();

            var viewModel = new ViewerFormViewModel
            {
                Viewer = viewer,
                MembershipTypes = context.MembershipTypes.ToList()
            };
        

            return View("ViewerForm", viewModel);
        }
    }//
}