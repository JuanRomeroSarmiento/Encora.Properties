using AutoMapper;
using Encora.Properties.Contracts.Dtos;
using Encora.Properties.Entities;

namespace Encora.Properties.ResourceAccessor.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PropertyDto, Property>();
            CreateMap<AddressDto, Address>();
        }
    }
}
