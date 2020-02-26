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
    public class ContractsController : ApiController
        
    {
        ApplicationDbContext context;

        public ContractsController()
        {
            context = new ApplicationDbContext();
        }



        // POST /api/contracts
        //[HttpPost] //WAY 1 => it gives back objects in the constructor
        //public IHttpActionResult CreateNewContract(NewContractDto newContractDto)
        //{
        //    //think before
        //    //Akyro the above : Get the newContract properties of Actor and Series list - > find them in db and create
        //    // a new contract foreach actor to each series

        //    var actor = context.Actors
        //        .Single(a => a.Id == newContractDto.ActorId);
        //    //for backend verification we make the bellow for the above and the if actor == null :
        //    //.SingleOrDefault(a => a.Id == newContractDto.ActorId);
        //    //if (actor == null)
        //    //    return BadRequest();

        //    var series = context.Series
        //        .Where(s => newContractDto.SerieIds.Contains(s.Id)).ToList(); //make a list of all the ids containing the SerieIds
        //    foreach (var serie in series)
        //    {
        //        var contract = new Contract()
        //        {
        //            Actor = actor,
        //            Serie = serie,
        //            DateInserted = DateTime.Now
        //        };
        //        context.Contracts.Add(contract);
        //    }
        //    context.SaveChanges();

        //    return Ok();
        //}

        [HttpPost] //WAY2 => GIVES directly the ids
        public IHttpActionResult CreateNewContract(NewContractDto newContractDto)
        {
            List<int> serieIds = new List<int>(newContractDto.SerieIds);

            foreach (var serieId in serieIds) //instead of the list serieIds we could have put newContractDto.SerieIds > it is also a list
            {
                var contract = new Contract()
                {
                    ActorId = newContractDto.ActorId,
                    SerieId = serieId,
                    DateInserted = DateTime.Now
                };
                context.Contracts.Add(contract);
            }
            context.SaveChanges();
            return Ok();
        }
    }////
}
