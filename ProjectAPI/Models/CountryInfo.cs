using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectAPI.Models
{
    public class CountryInfo
    {
        [Required]
        public string Email { get; set; }
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }

        public bool Isfavourite { get; set; }
    }
}
