using Encora.Properties.Contracts.Dtos;
using System.Threading.Tasks;

namespace Encora.Properties.Services.Interfaces
{
    public interface ILocalPropertyService
    {
        Task AddPropertyAsync(PropertyDto propertyDto);
        Task<bool> AnyPropertyByIdAsync(int id);
    }
}
