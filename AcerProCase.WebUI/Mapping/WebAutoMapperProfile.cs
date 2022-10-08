using AcerProCase.Entities.Concrete;
using AcerProCase.Entities.Concrete.DTOs.Response;
using AcerProCase.WebUI.Models;
using AutoMapper;

namespace AcerProCase.WebUI.Mapping
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<CountryInfoResponse, CountryModel>().ReverseMap();
            CreateMap<CountryInfo, CountryInfoModel>().ReverseMap();
        }
    }
}
