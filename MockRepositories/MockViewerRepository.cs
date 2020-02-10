using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;

namespace BootFlixBC9.MockRepositories
{
    public class MockViewerRepository
    {
        public IEnumerable<Viewer> GetViewers()
        {
            return new List<Viewer>
            {
                new Viewer { Id = 1 , Name = "Costas Spyrou"},
                new Viewer { Id = 2 , Name = "Pavlina Kostalea"}
            };
        }
       
    }
}