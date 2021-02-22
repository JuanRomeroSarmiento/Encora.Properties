namespace Encora.Properties.Entities
{
    public record Property
    {
        public Address Address { get; set; } // Not null
        public string YearBuilt { get; set; } // null (Physical Segment)
        public decimal ListPrice { get; set; } // null (Financial Segment)
        public decimal MonthlyRent { get; set; } // null (Financial Segment)
    }
}
