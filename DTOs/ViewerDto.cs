using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BootFlixBC9.DTOs
{
    public class ViewerDto
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]

        public DateTime? Birtdate { get; set; }

        public bool IsSubscribedToNews { get; set; }

        public byte MembershipTypeId { get; set; }

       // [Display(Name = "Membership Type")]

        public MembershipTypeDto MembershipType { get; set; } //AND navigation property -> virtual only for lazy loading

    }
}