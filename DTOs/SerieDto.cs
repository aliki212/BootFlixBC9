using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BootFlixBC9.DTOs
{
    public class SerieDto
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
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}