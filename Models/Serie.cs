using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC9.Models

{
    public class Serie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]

        public string Name { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Released")]

        public DateTime DateReleased { get; set; }

        public byte Seasons { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}