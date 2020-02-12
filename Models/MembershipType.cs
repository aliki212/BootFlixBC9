using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootFlixBC9.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        public short Price { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

    }
}