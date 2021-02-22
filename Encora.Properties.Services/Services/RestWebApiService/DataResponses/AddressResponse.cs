using Newtonsoft.Json;

namespace Encora.Properties.Services.Services.RestWebApiService.DataResponses
{    
    public class AddressResponse
    {
        [JsonProperty("address1")]
        public string AddressOne { get; set; } 

        [JsonProperty("address2")]
        public string AddressTwo { get; set; }         
        public string City { get; set; }         
        public string Country { get; set; }         
        public string County { get; set; }         
        public string District { get; set; }         
        public string State { get; set; }        
        public string Zip { get; set; }         
        public string ZipPlus4 { get; set; } 
    }
}
