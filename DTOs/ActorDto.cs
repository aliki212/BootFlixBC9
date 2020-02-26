using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BootFlixBC9.DTOs
{
    public class ActorDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }

        //public bool IsRegistered { get; set; }

     
    }
}