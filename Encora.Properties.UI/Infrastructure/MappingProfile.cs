using AutoMapper;
using Encora.Properties.Contracts.Dtos;
using Encora.Properties.UI.Models;

namespace Encora.Properties.UI.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PropertyDto, PropertyModel>()
                .ForMember(p => p.ListPrice, opt => opt.MapFrom(src => src.GetStringFormatListPrice()))
                .ForMember(p => p.MonthlyRent, opt => opt.MapFrom(src => src.GetStringFormatMonthlyRent()))
                .ForMember(p => p.GrossYield, opt => opt.MapFrom(src => src.GetStringFormatGrossYield()));
            CreateMap<AddressDto, AddressModel>();
            CreateMap<PropertyModel, PropertyDto>()
                .ForMember(p => p.ListPrice, opt => opt.MapFrom(src => src.GetDecimalNumberFromListPrice()))
                .ForMember(p => p.MonthlyRent, opt => opt.MapFrom(src => src.GetDecimalNumberFromMonthlyRent()))
                .ForMember(p => p.GrossYield, opt => opt.MapFrom(src => src.GetDecimalNumberFromGrossYield()));
            CreateMap<AddressModel, AddressDto>();
        }
    }
}
