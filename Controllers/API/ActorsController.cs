using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BootFlixBC9.Models;
using BootFlixBC9.DTOs;
using AutoMapper;

namespace BootFlixBC9.Controllers.API
{
    public class ActorsController : ApiController
    {
        private ApplicationDbContext context;

        public ActorsController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/actors
        public IHttpActionResult GetActors(string query = null)
        {
            var actorsQuery = context.Actors.AsQueryable(); //here we solved the below problem
            //var actorsQuery = context.Actors; //// just this line makes it a DbSet Object and below at IsNullOrWhiteSpace returns an Iqueriable which is caused by the .Where in LinQ 
            //// if we want to make the DbSet object to an equivalent to IQueriable - we use a query as well with Where which makes the var an IEnumerable which an be the same with an IQueriable
            ////.Where(a=>a.Age>10)
            //.ToList();
            //.Select(Mapper.Map<Actor, ActorDto>);

            if (!String.IsNullOrWhiteSpace(query))
                actorsQuery = actorsQuery.Where(a => a.Name.Contains(query));

            var actors = actorsQuery.ToList()
                .Select(Mapper.Map<Actor, ActorDto>);

            return Ok(actors);
        }
        ////The initial GetActors api with no query - we returned the query for bringing only 1 result
        //public IEnumerable<ActorDto> GetActors()
        //{
        //    return context.Actors
        //        .ToList()
        //        .Select(Mapper.Map<Actor, ActorDto>);
        //}

        [HttpPost]
        public IHttpActionResult CreateActor(ActorDto actorDto)
        {
            //actorDto.Age = (int)actorDto.Age;
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //var actor = Mapper.Map<ActorDto, Actor>(actorDto);

            var actor = new Actor(actorDto.Name, actorDto.Age, actorDto.Nationality);
            context.Actors.Add(actor);
            context.SaveChanges();

            return Ok();
        }

    }
}
