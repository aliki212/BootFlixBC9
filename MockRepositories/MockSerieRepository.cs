using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;

namespace BootFlixBC9.MockRepositories
{
    public class MockSerieRepository
    {
        public IEnumerable<Serie> GetSeries()
        {
            return new List<Serie>
            {
                new Serie { Id = 1, Name = "Lost"},
                new Serie { Id = 2, Name = "Game of Thrones"}
            };
        }
    }
}