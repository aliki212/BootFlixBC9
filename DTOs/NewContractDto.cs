using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootFlixBC9.DTOs
{
    public class NewContractDto
    {
        public int ActorId { get; set; }

        public List<int> SerieIds { get; set; } 
        // Same as having one Serie and a list of Actors for a MANY to MANY relationship
        // Here we had the Series ready so it will be easier for customers to add the existing series in the new Actor Contracts
    }
}