using AcerProCase.Entities.Concrete;
using AcerProCase.Entities.Concrete.DTOs.Response;
using AutoMapper;
using CountryInfoService;
using System;

namespace AcerProCase.Business.Mapping
{
    public class BusinessAutoMapperProfile : Profile
    {
        public BusinessAutoMapperProfile()
        {
            CreateMap<CountryInfoResponse, tCountryCodeAndName>().ReverseMap()
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.sISOCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.sName)); 
            
            CreateMap<CountryInfoResponse, tCurrency>().ReverseMap()
                .ForMember(dest => dest.ShortName, opt => opt.MapFrom(src => src.sISOCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.sName));

            CreateMap<Entities.Concrete.DTOs.Response.CountryNameResponse, CountryISOCodeResponseBody>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CountryISOCodeResult));

        }
    }

    public static class BusinessMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<BusinessAutoMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
