using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC9.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter the Actor's Name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Nationality { get; set; }

        //public bool IsRegistered { get; set; }
    }
}