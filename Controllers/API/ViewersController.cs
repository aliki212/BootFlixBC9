using BootFlixBC9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using BootFlixBC9.DTOs;

namespace BootFlixBC9.Controllers.API
{
    public class ViewersController : ApiController
    {
        private ApplicationDbContext context;// = new ApplicationDbContext();
        public ViewersController()
        {
            context = new ApplicationDbContext();
        }


        //GET /api/viewers
        //Initial method of GetViewers without Dtos/AutoMapper - simple API
        //public IEnumerable<Viewer> GetViewers()
        //{
        //    return context.Viewers.ToList();
        //}
        public IEnumerable<ViewerDto> GetViewers()
        {
            return context.Viewers.ToList()
                .Select(Mapper.Map<Viewer, ViewerDto>);
        }

        // GET /api/viewers/id
        //Change ViewerDto to iHttpActionResult
        public IHttpActionResult GetViewer(int id)
        {
            var viewer = context.Viewers.SingleOrDefault(c => c.Id == id);
                if(viewer == null)
                return NotFound(); //since now it is an IHttpActionResult type of method we can return an Http type
                //throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Viewer, ViewerDto>(viewer));
        }

        // POST /api/viewers
        [HttpPost]
        public IHttpActionResult CreateViewer(ViewerDto viewerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var viewer = Mapper.Map<ViewerDto, Viewer>(viewerDto);

            context.Viewers.Add(viewer);
            context.SaveChanges();
            //show where the created resource is located
            return Created(new Uri(Request.RequestUri + "/" + viewer.Id), viewerDto);
        }

        // PUT /api/viewer/id

        [HttpPut]
        public void UpdateViewer(int id, ViewerDto viewerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var viewerDb = context.Viewers.SingleOrDefault(c => c.Id == id);
            if (viewerDb == null) // if the db viewer from the id =null
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(viewerDto, viewerDb);
            //viewerDb.Name = viewer.Name;
            //viewerDb.Birtdate = viewer.Birtdate;
            //viewerDb.IsSubscribedToNews = viewer.IsSubscribedToNews;
            //viewerDb.MembershipTypeId = viewer.MembershipTypeId;

            context.SaveChanges();
        }

        //DELETE /api/viewers/id
        //no changes for Dto implementation
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
