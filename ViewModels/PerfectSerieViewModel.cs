using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;

namespace BootFlixBC9.ViewModels
{
    public class PerfectSerieViewModel
    {
        public Serie Serie { get; set; }
        public List<Viewer> Viewers {get; set;}
    }
}