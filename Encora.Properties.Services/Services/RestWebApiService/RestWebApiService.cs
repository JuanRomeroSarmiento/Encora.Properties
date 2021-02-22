using Encora.Properties.Contracts.Dtos;
using Encora.Properties.Services.Infrastructure;
using Encora.Properties.Services.Interfaces;
using Encora.Properties.Services.Services.RestWebApiService.DataResponses;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Encora.Properties.Services.Services.RestWebApiService
{
    public class RestWebApiService : IRestWebApiService
    {
        private readonly ILogger<RestWebApiService> _logger;
        private readonly IHttpClientFactory _clientFactory;
        
        public RestWebApiService(
            ILogger<RestWebApiService> logger,
            IHttpClientFactory clientFactory) 
        {
            _logger = logger;
            _clientFactory = clientFactory;            
        }
        public async Task<ICollection<PropertyDto>> GetPropertiesAsync()
        {            
            var _client = _clientFactory.CreateClient("PropertyClient");            

            var httpResponse = await _client.GetAsync("public/properties.json");
            if (!httpResponse.IsSuccessStatusCode)
            {
                _logger.Log(LogLevel.Error, string.Format(
                    Constants.ErrorFromRestAPI, 
                    httpResponse.StatusCode, 
                    _client.BaseAddress.AbsoluteUri));
                throw new Exception();
            }
            
            var jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            return getPropertiesFromString(jsonResponse);
        }

        private ICollection<PropertyDto> getPropertiesFromString(string properties)
        {
            IList<PropertyDto> result = new List<PropertyDto>();
            var listOfProperityObjects = JsonConvert.DeserializeObject<PropertiesResponse>(properties);

            listOfProperityObjects.Properties.ForEach(property =>
            {
                var newPropertyDto = new PropertyDto
                {
                    Id = property.Id,
                    YearBuilt = (property.Physical != null) ? property.Physical.YearBuilt : null,
                    ListPrice = (property.Financial != null) ? property.Financial.ListPrice : null,
                    MonthlyRent = (property.Financial != null) ? property.Financial.MonthlyRent : null,
                    Address = new AddressDto
                    {
                        AddressOne = property.Address.AddressOne,
                        AddressTwo = property.Address.AddressTwo,
                        City = property.Address.City,
                        Country = property.Address.Country,
                        County = property.Address.County,
                        District = property.Address.District,
                        State = property.Address.State,
                        Zip = property.Address.Zip,
                        ZipPlus4 = property.Address.ZipPlus4
                    }
                };
                newPropertyDto.calculateGrossYield();
                result.Add(newPropertyDto);
            });

            return result;
        }
    }
}
