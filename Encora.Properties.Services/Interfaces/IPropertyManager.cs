using Encora.Properties.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Encora.Properties.Services.Interfaces
{
    public interface IPropertyManager
    {
        Task<bool> AddPropertyAsync(PropertyDto propertyDto);
        Task<ICollection<PropertyDto>> GetAllPropertiesAsync();
    }
}
