using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BootFlixBC9.Models;

namespace BootFlixBC9.ViewModels
{
    public class NewViewerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes;

        public Viewer Viewer { get; set; }
    }
}