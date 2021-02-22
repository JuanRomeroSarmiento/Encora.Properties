using Encora.Properties.Contracts.Dtos;
using System.Threading.Tasks;

namespace Encora.Properties.ResourceAccessor.Interfaces
{
    public interface IPropertyRepository
    {
        Task AddPropertyAsync(PropertyDto propertyDto);

        Task<bool> AnyPropertyByIdAsync(int id);
    }
}
