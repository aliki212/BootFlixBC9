using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BootFlixBC9.Models;
using AutoMapper;
using BootFlixBC9.DTOs;


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

    }
}
