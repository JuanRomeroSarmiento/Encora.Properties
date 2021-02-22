namespace Encora.Properties.Entities
{
    public class Property
    {
        public int Id { get; set; }        
        public string YearBuilt { get; set; }
        public decimal? ListPrice { get; set; } 
        public decimal? MonthlyRent { get; set; } 
        public decimal? GrossYield { get; set; } 
        public virtual Address Address { get; set; } 
    }
}
