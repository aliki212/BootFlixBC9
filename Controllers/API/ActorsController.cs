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

        public IEnumerable<ActorDto> GetActors()
        {
            return context.Actors
                .ToList()
                .Select(Mapper.Map<Actor, ActorDto>);
        }

    }
}
