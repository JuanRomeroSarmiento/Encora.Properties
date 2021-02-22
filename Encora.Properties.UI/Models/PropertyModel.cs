using System.ComponentModel.DataAnnotations;

namespace Encora.Properties.UI.Models
{
    public class PropertyModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Year Built")]
        public string YearBuilt { get; set; }

        [Display(Name = "List Price")]        
        public string ListPrice { get; set; }

        [Display(Name = "Monthly Rent")]
        public string MonthlyRent { get; set; }

        [Display(Name = "Gross Yield")]
        public string GrossYield { get; set; }

        [Display(Name = "Address")]
        public AddressModel Address { get; set; }

        public decimal GetDecimalNumberFromListPrice()
        {            
            if(ListPrice != null)
             return decimal.Parse(ListPrice.Replace("$", ""));

            return default;
        }           
             
        public decimal GetDecimalNumberFromMonthlyRent()
        {
            if(MonthlyRent != null)
                decimal.Parse(MonthlyRent.Replace("$", ""));

            return default;
        }      
              
        public decimal GetDecimalNumberFromGrossYield()
        {
            if(GrossYield != null)
                decimal.Parse(GrossYield.Replace("%", ""));

            return default;
        }                           
    }
}
