using AcerProCase.Business.Abstract;
using AcerProCase.Entities.Concrete.DTOs.Request;
using AcerProCase.WebUI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AcerProCase.WebUI.ViewComponents
{
    public class CountryInfoComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly ICountryInfoService _countryInfoService;
        public CountryInfoComponent(IMapper mapper, ICountryInfoService countryInfoService)
        {
            _mapper = mapper;
            _countryInfoService = countryInfoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(CountryInfoRequest input)
        {
            var result = await _countryInfoService.GetCountryInfoAsync(input);
            if (!result.Success)
            {
                return View();
            }
            return View(_mapper.Map<CountryInfoModel>(result.Data));
        }
    }
}
