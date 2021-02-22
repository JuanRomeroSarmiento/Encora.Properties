namespace Encora.Properties.Entities
{
    public class Address
    {        
        public string AddressOne { get; set; } 
        public string AddressTwo { get; set; } 
        public string City { get; set; } 
        public string Country { get; set; } 
        public string County { get; set; } 
        public string District { get; set; } 
        public string State { get; set; } 
        public string Zip { get; set; } 
        public string ZipPlus4 { get; set; } 

        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
