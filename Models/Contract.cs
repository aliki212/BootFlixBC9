using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BootFlixBC9.Models
{
    public class Contract
    {
        public int Id { get; set; }

        [Required]
        public int ActorId { get; set; }

        public Actor Actor { get; set; }

        [Required]
        public int SerieId { get; set; }

        public Serie Serie { get; set; }

        public string Character { get; set; }

        public DateTime DateInserted { get; set; } //Date record inserted in database
    }
}