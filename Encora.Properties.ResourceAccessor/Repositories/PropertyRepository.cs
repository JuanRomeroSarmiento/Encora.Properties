using AutoMapper;
using Encora.Properties.Contracts.Dtos;
using Encora.Properties.DataBase;
using Encora.Properties.Entities;
using Encora.Properties.ResourceAccessor.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Encora.Properties.ResourceAccessor.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyDBContext _propertyDBContext;
        private readonly IMapper _mapper;

        public PropertyRepository(
            PropertyDBContext propertyDBContext,
            IMapper mapper)
        {
            _propertyDBContext = propertyDBContext;
            _mapper = mapper;
        }
        public async Task AddPropertyAsync(PropertyDto propertyDto)
        {            
            Property newProperty = _mapper.Map<Property>(propertyDto);
            await _propertyDBContext.Property.AddAsync(newProperty);
            await _propertyDBContext.SaveChangesAsync();
        }

        public async Task<bool> AnyPropertyByIdAsync(int id) =>        
            await _propertyDBContext.Property.AnyAsync(p => p.Id == id);
        
    }
}
