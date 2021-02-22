using Encora.Properties.Contracts.Dtos;
using Encora.Properties.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encora.Properties.Services
{
    public class Manager : IPropertyManager
    {
        private readonly ILocalPropertyService _localPropertyService;
        private readonly IRestWebApiService _restWebApiService;

        public Manager(
            ILocalPropertyService localPropertyService,
            IRestWebApiService restWebApiService)
        {
            _localPropertyService = localPropertyService;
            _restWebApiService = restWebApiService;
        }

        public async Task<bool> AddPropertyAsync(PropertyDto propertyDto)
        {
            var result = false;
            if (await _localPropertyService.AnyPropertyByIdAsync(propertyDto.Id))
                return result;

            propertyDto.calculateGrossYield();            
            await _localPropertyService.AddPropertyAsync(propertyDto);
            result = true;
            return result;
        }            

        public Task<ICollection<PropertyDto>> GetAllPropertiesAsync() =>
            _restWebApiService.GetPropertiesAsync();
       
    }
}
