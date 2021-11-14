using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Domain
{
    public class Address
    {
        public int Id {get;set;}
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public string Details { get; set; }

        public string ZipCode { get; set; }

        [Required]
        public Guid AppUserId { get; set; }

        public AppUser AppUser { get; set; }

    }
}