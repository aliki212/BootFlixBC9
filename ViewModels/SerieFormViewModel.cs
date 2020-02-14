using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;

namespace BootFlixBC9.ViewModels
{
    public class SerieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int Id { get; set; }

        [Required]
        [StringLength(225)]

        public string Name { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Released")]

        public DateTime DateReleased { get; set; }

        [Range(1,20)]
        [Required]
        public byte Seasons { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        
        public string Title { get
            {
                return Id != 0 ? "Edit Serie" : "New Serie";

            } }
        //NO MORE public Serie Serie { get; set; }
        public SerieFormViewModel(Serie serie)
        {
            Id = serie.Id;
            Name = serie.Name;
            DateReleased = serie.DateReleased;
            Seasons = serie.Seasons;
            GenreId = serie.GenreId;
        }
        public SerieFormViewModel()
        {
            Id = 0;
        }
    }
}