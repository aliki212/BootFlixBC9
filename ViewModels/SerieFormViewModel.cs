using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;

namespace BootFlixBC9.ViewModels
{
    public class SerieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Serie Serie { get; set; }
        
        public string Title { get
            {
                
                    if (Serie != null && Serie.Id != 0)
                    {
                        return "Edit Serie";
                    }
                    return "New Serie";
                }
                        }
    }
}