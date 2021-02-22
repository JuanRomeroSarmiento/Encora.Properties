using System.ComponentModel.DataAnnotations;

namespace Encora.Properties.UI.Models
{
    public class AddressModel
    {
        [Required]
        [Display(Name = "Address 1")]
        public string AddressOne { get; set; }

        [Display(Name = "Address 2")]
        public string AddressTwo { get; set; }

        [Required]       
        public string City { get; set; }

        [Required]        
        public string Country { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }
    }
}
