namespace Encora.Properties.Entities
{
    public record Address
    {
        public string AddressOne { get; set; } // Not null
        public string AddressTwo { get; set; } // null
        public string City { get; set; } // Not null 
        public string Country { get; set; } // Not null
        public string County { get; set; } // Null
        public string District { get; set; } // Null
        public string State { get; set; } // Not Null
        public string Zip { get; set; } // Not Null
        public string ZipPlus4 { get; set; } // Null
    }
}
