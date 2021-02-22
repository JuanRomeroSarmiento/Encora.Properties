namespace Encora.Properties.Contracts.Dtos
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string YearBuilt { get; set; } 
        public decimal? ListPrice { get; set; } 
        public decimal? MonthlyRent { get; set; }
        public decimal? GrossYield { get; set; }
        public AddressDto Address { get; set; }
        
        public void calculateGrossYield()
        {
            if(isValidObjectForCalculatingGrossYield())
            {
                var grossYieldCalculated = (this.MonthlyRent * 12 / this.ListPrice) * 100;
                this.GrossYield = decimal.Round((decimal)grossYieldCalculated, 2);
            }           
        }

        public string GetStringFormatListPrice() =>        
            (ListPrice != null) ? $"${string.Format("{0:N2}", ListPrice)}" : null ;
        
        public string GetStringFormatMonthlyRent() =>        
             (MonthlyRent != null) ? $"${string.Format("{0:N2}", MonthlyRent)}" : null;

        public string GetStringFormatGrossYield() =>
            (GrossYield != null) ? $"{GrossYield}%" : null;

        private bool isValidObjectForCalculatingGrossYield()
        {
            if (this.ListPrice == null)
                return false;
            if (this.ListPrice == 0)
                return false;
            if (this.MonthlyRent == null)
                return false;

            return true;
        }

    }
}
