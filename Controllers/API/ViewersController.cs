using BootFlixBC9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BootFlixBC9.Controllers.API
{
    public class ViewersController : ApiController
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        //public class ViewersController 
        //{ 
        //    context = new ApplicationDbContext;
        //}


            //GET /api/viewers
        public IEnumerable<Viewer> GetViewers()
        {
            return context.Viewers.ToList();
        }

        // GET /api/viewers/id
        public Viewer GetViewer(int id)
        {
            var viewer = context.Viewers.SingleOrDefault(c => c.Id == id);
                if(viewer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return viewer;
        }

        // POST /api/viewers
        [HttpPost]
        public Viewer CreateViewer(Viewer viewer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Viewers.Add(viewer);
            context.SaveChanges();
            return viewer;
        }



    }//
}
