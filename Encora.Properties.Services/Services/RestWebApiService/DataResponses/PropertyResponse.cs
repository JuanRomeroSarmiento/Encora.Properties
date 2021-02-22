using Encora.Properties.Services.Services.RestWebApiService.DataResponses;

namespace Encora.Services.Services.RestWebApiService.DataResponses
{
    public class PropertyResponse
    {        
        public int Id { get; set; }
        public virtual PhysicalResponse Physical { get; set; }
        public virtual FinancialResponse Financial { get; set; }        
        public virtual AddressResponse Address { get; set; }
    }
}
