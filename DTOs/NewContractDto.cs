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

            /// <summary>
            /// Created the default constructor for the WAY 2 of API POST of a new contract > we create an empty list in case of no
            /// series when submitted > the api call returns valid (with the response of toast js) but the contract is not created
            /// </summary>
        public NewContractDto()
        {
            SerieIds = new List<int>();
        }
    }
}