using Encora.Properties.Contracts.Dtos;
using Encora.Properties.ResourceAccessor.Interfaces;
using Encora.Properties.Services.Interfaces;
using System.Threading.Tasks;

namespace Encora.Properties.Services.Services.LocalServices
{
    public class LocalPropertyService : ILocalPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public LocalPropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public Task AddPropertyAsync(PropertyDto propertyDto) =>        
            _propertyRepository.AddPropertyAsync(propertyDto);


        public Task<bool> AnyPropertyByIdAsync(int id) =>
            _propertyRepository.AnyPropertyByIdAsync(id);
        
    }
}
