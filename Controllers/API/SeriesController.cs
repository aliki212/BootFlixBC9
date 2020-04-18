using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BootFlixBC9.Models;
using AutoMapper;
using BootFlixBC9.DTOs;
using System.Data.Entity;


namespace BootFlixBC9.Controllers.API
{
    public class SeriesController : ApiController
    {

        private ApplicationDbContext context;
        //part2
        public SeriesController()
        {
            context = new ApplicationDbContext();
        }


        //GET /api/series
        //first initial version b4 the actors new contract call
        //public IEnumerable<SerieDto> GetSeries()
        //{
        //    return context.Series
        //        .Include(s => s.Genre)
        //        .ToList()
        //        .Select(Mapper.Map<Serie, SerieDto>);
        //}
        public IHttpActionResult GetSeries(string query = null)
        {
            var seriesQuery = context.Series
                .Include(s => s.Genre)
                .AsQueryable();
            // .Where(s => s.IsReleased == true);
            if (!String.IsNullOrWhiteSpace(query))
                seriesQuery = seriesQuery.Where(s => s.Name.Contains(query));

            var series = seriesQuery
                .ToList()
                .Select(Mapper.Map<Serie, SerieDto>);

            return Ok(series);
        }

        // GET /api/series/id
        public IHttpActionResult GetSeries(int id)
        {
            var serie = context.Series.SingleOrDefault(c => c.Id == id);
            if (serie == null)
                return NotFound();

            return Ok(Mapper.Map<Serie, SerieDto>(serie));
        }

        // POST /api/viewers
        [HttpPost]
        public IHttpActionResult CreateSerie(SerieDto serieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var serie = Mapper.Map<SerieDto, Serie>(serieDto);

            context.Series.Add(serie);
            context.SaveChanges();
            //return serieDto;
            return Created(new Uri(Request.RequestUri + "/" + serie.Id), serieDto);
        }

        // PUT /api/serie/id

        [HttpPut]
        public void UpdateSerie(int id, SerieDto serieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var serieDb = context.Viewers.SingleOrDefault(c => c.Id == id);
            if (serieDb == null) // if the db viewer from the id =null
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(serieDto, serieDb);
            //viewerDb.Name = viewer.Name;
            //viewerDb.Birtdate = viewer.Birtdate;
            //viewerDb.IsSubscribedToNews = viewer.IsSubscribedToNews;
            //viewerDb.MembershipTypeId = viewer.MembershipTypeId;

            context.SaveChanges();
        }

        //DELETE /api/viewer/id
        //no changes for Dto implementation
        [HttpDelete]
        public void DeleteSerie(int id)
        {
            var serieDb = context.Series.SingleOrDefault(v => v.Id == id);
            if (serieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            context.Series.Remove(serieDb);
            context.SaveChanges();
        }
    }
}
