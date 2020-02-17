using BootFlixBC9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

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

        // PUT /api/viewer/id

        [HttpPut]
        public void UpdateViewer(int id, Viewer viewer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var viewerDb = context.Viewers.SingleOrDefault(c => c.Id == id);
            if (viewerDb == null) // if the db viewer from the id =null
                throw new HttpResponseException(HttpStatusCode.NotFound);
            viewerDb.Name = viewer.Name;
            viewerDb.Birtdate = viewer.Birtdate;
            viewerDb.IsSubscribedToNews = viewer.IsSubscribedToNews;
            viewerDb.MembershipTypeId = viewer.MembershipTypeId;

            context.SaveChanges();
        }

        //DELETE /api/viewer/id
        [HttpDelete]
        public void DeleteViewer(int id)
        {
            var viewerDb = context.Viewers.SingleOrDefault(v => v.Id == id);
            if (viewerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Viewers.Remove(viewerDb);
            context.SaveChanges();
        }

    }//
}
